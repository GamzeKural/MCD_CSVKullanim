using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MCD_CSVKullanim
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Musteri> Musterilerim = new List<Musteri>();
            for (int i = 0; i < 50; i++)
            {
                Musteri temp = new Musteri();
                temp.ID = i.ToString();
                temp.Isim = FakeData.NameData.GetFirstName();
                temp.Soyisim = FakeData.NameData.GetSurname();
                temp.EmailAdres = temp.Isim + "." + temp.Soyisim + "@" + FakeData.NetworkData.GetDomain();
                temp.TelefonNumara = FakeData.PhoneNumberData.GetPhoneNumber();
                Musterilerim.Add(temp);
            }

            StreamWriter SW = new StreamWriter(@"c:\CSV\Musteriler.csv");
            CsvHelper.CsvWriter write = new CsvHelper.CsvWriter(SW, System.Globalization.CultureInfo.CurrentCulture);
            write.WriteHeader(typeof(Musteri));
            write.NextRecord();
            foreach (Musteri item in Musterilerim)
            {
                write.WriteRecord(item);
                write.NextRecord();
            }
            SW.Close();

            //dosyadan okuma
            StreamReader SR = new StreamReader(@"c:\CSV\Musteriler.csv");
            CsvHelper.CsvReader Reader = new CsvHelper.CsvReader(SR, System.Globalization.CultureInfo.CurrentCulture);
            List<Musteri> OkunanData = Reader.GetRecords<Musteri>().ToList();
            foreach (var musteri in OkunanData)
            {
                Console.WriteLine(musteri.ID + ";" + musteri.Isim + ";" + musteri.Soyisim + ";" + musteri.EmailAdres + ";" + musteri.TelefonNumara);
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}
