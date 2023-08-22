using System;
using System.Collections.Generic;

class Program
{
    static List<TaskItem> taskList = new List<TaskItem>(); // List untuk menyimpan tugas-tugas

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("To-Do List Manager");
            Console.WriteLine("1. Tambah Tugas");
            Console.WriteLine("2. Lihat Daftar Tugas");
            Console.WriteLine("3. Tandai Tugas Sebagai Selesai");
            Console.WriteLine("4. Hapus Tugas");
            Console.WriteLine("5. Keluar");
            Console.Write("\nPilih opsi: ");
            string choice = Console.ReadLine(); // Mengambil pilihan dari user

            switch (choice)
            {
                case "1":
                    TambahTugas(); // Memanggil fungsi untuk menambah tugas
                    break;
                case "2":
                    LihatDaftarTugas(); // Memanggil fungsi untuk melihat daftar tugas
                    break;
                case "3":
                    TandaiTugasSelesai(); // Memanggil fungsi untuk menandai tugas sebagai selesai
                    break;
                case "4":
                    HapusTugas(); // Memanggil fungsi untuk menghapus tugas
                    break;
                case "5":
                    exit = true; // Keluar dari program
                    break;
                default:
                    Console.WriteLine("Opsi tidak valid. Silakan pilih lagi.");
                    break;
            }
        }
    }

    static void TambahTugas()
    {
        Console.Write("Masukkan nama tugas: ");
        string name = Console.ReadLine(); // Mengambil nama tugas dari user
        Console.Write("Masukkan deskripsi tugas: ");
        string description = Console.ReadLine(); // Mengambil deskripsi tugas dari user
        taskList.Add(new TaskItem(name, description, false)); // Menambahkan tugas baru ke dalam list
        Console.WriteLine("Tugas ditambahkan.");
    }

    static void LihatDaftarTugas()
    {
        if (taskList.Count == 0)
        {
            Console.WriteLine("Tidak ada tugas yang ditemukan.");
            return;
        }

        Console.WriteLine("Daftar Tugas:");
        for (int i = 0; i < taskList.Count; i++)
        {
            TaskItem task = taskList[i];
            Console.WriteLine($"{i + 1}. [{(task.Completed ? "X" : " ")}] {task.Name} - {task.Description}");
            // Menampilkan daftar tugas beserta status (selesai/belum) dan deskripsi
        }
    }

    static void TandaiTugasSelesai()
    {
        LihatDaftarTugas();
        Console.Write("Masukkan nomor tugas yang akan ditandai sebagai selesai: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= taskList.Count)
        {
            taskList[index - 1].Completed = true; // Menandai tugas sebagai selesai
            Console.WriteLine("Tugas ditandai sebagai selesai.");
        }
        else
        {
            Console.WriteLine("Nomor tugas tidak valid.");
        }
    }

    static void HapusTugas()
    {
        LihatDaftarTugas();
        Console.Write("Masukkan nomor tugas yang akan dihapus: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= taskList.Count)
        {
            taskList.RemoveAt(index - 1); // Menghapus tugas dari list
            Console.WriteLine("Tugas dihapus.");
        }
        else
        {
            Console.WriteLine("Nomor tugas tidak valid.");
        }
    }
}

class TaskItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public TaskItem(string name, string description, bool completed)
    {
        Name = name;
        Description = description;
        Completed = completed;
    }
}
