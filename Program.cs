using System;

namespace tpmodul8_NIM
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = new CovidConfig();

            Console.WriteLine("=== APLIKASI PENERIMAAN MASUK GEDUNG ===");

            Console.Write($"Berapa suhu badan anda saat ini? (dalam {config.satuan_suhu}): ");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
            int hariDemam = Convert.ToInt32(Console.ReadLine());

            bool suhuValid = false;

            if (config.satuan_suhu?.ToLower() == "celcius")
            {
                suhuValid = (suhu >= 36.5 && suhu <= 37.5);
            }
            else if (config.satuan_suhu?.ToLower() == "fahrenheit")
            {
                suhuValid = (suhu >= 97.7 && suhu <= 99.5);
            }

            bool hariValid = (hariDemam < config.batas_hari_deman);

            if (suhuValid && hariValid)
            {
                Console.WriteLine(config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(config.pesan_ditolak);
            }

            Console.WriteLine("\n=== DEMO UBAH SATUAN ===");
            config.UbahSatuan();

            Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
            Console.ReadKey();
        }
    }
}