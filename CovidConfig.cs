using System;
using System.IO;
using Newtonsoft.Json;

public class CovidConfig
{
    public string? satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string? pesan_ditolak { get; set; }
    public string? pesan_diterima { get; set; }

    private const string configFile = "covid_config.json";

    public CovidConfig()
    {
        LoadConfig();
    }

    private void LoadConfig()
    {
        if (File.Exists(configFile))
        {
            string json = File.ReadAllText(configFile);
           
            var tempConfig = JsonConvert.DeserializeObject<CovidConfigTemp>(json);
            if (tempConfig != null)
            {
                satuan_suhu = tempConfig.satuan_suhu;
                batas_hari_deman = tempConfig.batas_hari_deman;
                pesan_ditolak = tempConfig.pesan_ditolak;
                pesan_diterima = tempConfig.pesan_diterima;
                return;
            }
        }

        
        satuan_suhu = "celcius";
        batas_hari_deman = 14;
        pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        SaveConfig();
    }

    public void SaveConfig()
    {
        var tempConfig = new CovidConfigTemp
        {
            satuan_suhu = this.satuan_suhu,
            batas_hari_deman = this.batas_hari_deman,
            pesan_ditolak = this.pesan_ditolak,
            pesan_diterima = this.pesan_diterima
        };
        string json = JsonConvert.SerializeObject(tempConfig, Formatting.Indented);
        File.WriteAllText(configFile, json);
    }

    public void UbahSatuan()
    {
        if (satuan_suhu?.ToLower() == "celcius")
            satuan_suhu = "fahrenheit";
        else
            satuan_suhu = "celcius";
        SaveConfig();
        Console.WriteLine($"Satuan suhu telah diubah menjadi {satuan_suhu}");
    }
}

internal class CovidConfigTemp
{
    public string? satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string? pesan_ditolak { get; set; }
    public string? pesan_diterima { get; set; }
}