using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public static class FileProcessor
    {
        /// <summary>
        /// 將資料寫入文字檔中
        /// </summary>
        /// <typeparam name="T">type of data</typeparam>
        /// <param name="data">list of data</param>
        /// <param name="filepath">filepath and filename</param>
        public static void SaveToTextFile<T>(IEnumerable<T> data, string filepath) where T: class, new()
        {
            List<string> lines = new List<string>();

            if (data.Count() < 1)
            {
                throw new ArgumentNullException("未傳入任何資料!");
            }

            //取得傳入實體的class的全部屬性
            //(因為已有實體, 所以直接拿來取屬性)
            var cols = data.ElementAt(0).GetType().GetProperties();

            //make header, must skip the first common
            var headers = cols.Select(c => c.Name).Aggregate(string.Empty, (str, current) => $"{str},{current}").Substring(1);
            lines.Add(headers);

            foreach (var row in data)
            {
                var line = cols.Aggregate(string.Empty, (str, col) => $"{str},{col.GetValue(row)}").Substring(1);
                lines.Add(line);
            }

            System.IO.File.WriteAllLines(filepath, lines);
        }

        /// <summary>
        /// 由文字檔(csv)載入資料
        /// </summary>
        /// <typeparam name="T">type of data</typeparam>
        /// <param name="filepath">filepath and filename</param>
        /// <returns></returns>
        public static List<T> LoadFromTextFile<T>(string filepath) where T : class, new()
        {
            List<T> output = new List<T>();

            //為了取得class property, 需要new一個實體
            T entry = new T();

            //using reflection
            var cols = entry.GetType().GetProperties();

            //read text file
            var lines = System.IO.File.ReadAllLines(filepath).ToList();

            //check data is empty
            if (lines.Count() < 2)
            {
                throw new IndexOutOfRangeException("檔案中無任何資料!");
            }

            //讀取header
            var header = lines.First().Split(',');

            //移除header line
            lines.RemoveAt(0);

            //讀取資料
            foreach (var line in lines)
            {
                entry = new T();

                //將每一行的資料拆分
                var vals = line.Split(',').ToList();

                //以header的個數就知道有多少個column
                for (int i = 0; i < header.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if (col.Name == header.ElementAt(i))
                        {
                            //文字檔中讀回的都是字串, 需將字串轉換為對應的property的型別
                            //使用動態型別轉換
                            col.SetValue(entry, Convert.ChangeType(vals.ElementAt(i), col.PropertyType));
                        }
                    }
                }

                output.Add(entry);
            }

            return output;
        }
    }
}
