# C# Dependency Injection with Autofac (Tim Corey)

https://www.youtube.com/watch?v=mCUNrRtVVWY&t=255s


## Challenge
1. 作為C#程式設計師, 我要以DI實踐DIP原則
2. 作為DI實踐, 我要以Autofac實作DI

## 架構
1. 主程式: ConsoleUI
2. 函式庫: DemoLibrary
  - ILogger
    * Log(string)
  - IDataAccess
    * LoadData()
	* SaveData(string)
  - IBusiness
    * ProcessData()
  - IApplication
    * Run()

## 環境
- VS2017

## 套件
- Autofac