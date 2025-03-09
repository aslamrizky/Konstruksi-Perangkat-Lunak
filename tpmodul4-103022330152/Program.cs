// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class KodePos
{
    private static readonly Dictionary<string, string> kodePosMap = new Dictionary<string, string>
    {
        {"Batununggal", "40266"},
        {"Kujangsari", "40287"},
        {"Mengger", "40267"},
        {"Wates", "40256"},
        {"Cijaura", "40287"},
        {"Jatisari", "40286"},
        {"Margasari", "40286"},
        {"Sekejati", "40286"},
        {"Kebonwaru", "40272"},
        {"Maleer", "40274"},
        {"Samoja", "40273"}
    };

    public static string GetKodePos(string kelurahan)
    {
        return kodePosMap.ContainsKey(kelurahan) ? kodePosMap[kelurahan] : "Kode pos tidak ditemukan";
    }
}

class DoorMachine
{
    private IState state;

    public DoorMachine()
    {
        this.state = new LockedState(); 
    }

    public void SetState(IState state)
    {
        this.state = state;
    }

    public void Lock()
    {
        state.Lock(this);
    }

    public void Unlock()
    {
        state.Unlock(this);
    }
}

interface IState
{
    void Lock(DoorMachine door);
    void Unlock(DoorMachine door);
}

class LockedState : IState
{
    public void Lock(DoorMachine door)
    {
        Console.WriteLine("Pintu sudah terkunci");
    }

    public void Unlock(DoorMachine door)
    {
        Console.WriteLine("Pintu tidak terkunci");
        door.SetState(new UnlockedState());
    }
}

class UnlockedState : IState
{
    public void Lock(DoorMachine door)
    {
        Console.WriteLine("Pintu terkunci");
        door.SetState(new LockedState());
    }

    public void Unlock(DoorMachine door)
    {
        Console.WriteLine("Pintu sudah tidak terkunci");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Kode Pos Batununggal: " + KodePos.GetKodePos("Batununggal"));
        Console.WriteLine("Kode Pos Kujangsari: " + KodePos.GetKodePos("Kujangsari"));
        Console.WriteLine("Kode Pos Mengger: " + KodePos.GetKodePos("Mengger"));
        Console.WriteLine("Kode Pos Wates: " + KodePos.GetKodePos("Wates"));
        Console.WriteLine("Kode Pos Cijaura: " + KodePos.GetKodePos("Cijaura"));
        Console.WriteLine("Kode Pos Jatisari: " + KodePos.GetKodePos("Jatisari"));
        Console.WriteLine("Kode Pos Margasari: " + KodePos.GetKodePos("Margasari"));
        Console.WriteLine("Kode Pos Sekejati: " + KodePos.GetKodePos("Sekejati"));
        Console.WriteLine("Kode Pos Kebonwaru: " + KodePos.GetKodePos("Kebonwaru"));
        Console.WriteLine("Kode Pos Maleer: " + KodePos.GetKodePos("Maleer"));
        Console.WriteLine("Kode Pos Samoja: " + KodePos.GetKodePos("Samoja"));

        DoorMachine door = new DoorMachine();
        door.Unlock();
        door.Lock();
    }
}
