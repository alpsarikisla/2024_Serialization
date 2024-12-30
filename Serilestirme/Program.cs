using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serilestirme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogr = new Ogrenci() { isim = "murtaza", soyisim = "şuayipoğlu", yas=19 };
            //Binary Serialization
            //byte[] gelen = Binaryserialize(ogr);
            //foreach (byte item in gelen)
            //{
            //    Console.Write(item);
            //}
            //Console.WriteLine();
            //Ogrenci BinaryToString = (Ogrenci)BinaryDeserialize(gelen);
            //Console.WriteLine(BinaryToString.isim + " "+ BinaryToString.soyisim);

            //string gelen = JsonSerialize(ogr);
            //Console.WriteLine(gelen);

            string gelen = XmlSerialize(ogr);
            Console.WriteLine(gelen);

            Ogrenci ogr2 = XmlDeSerialize();
            Console.WriteLine(ogr2.isim + " " +ogr2.soyisim);
        }
        public static byte[] Binaryserialize(object veri)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, veri);
                return ms.ToArray();
            }
        }
        public static object BinaryDeserialize(byte[] veri)
        {
            using (MemoryStream ms = new MemoryStream(veri))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(ms);
            }
        }
        public static string JsonSerialize(object veri)
        {
            return JsonConvert.SerializeObject(veri);
        }
        public static object JsonDeserialize(string veri)
        {
            return JsonConvert.DeserializeObject(veri);
        }
        public static string XmlSerialize(object veri)
        {
            using (StreamWriter ms = new StreamWriter("ogrenci.xml"))
            {
                XmlSerializer serilestirici = new XmlSerializer(typeof(Ogrenci));
                serilestirici.Serialize(ms, veri);
                return ms.ToString();
            }
        }
        public static Ogrenci XmlDeSerialize()
        {
            using (StreamReader sr = new StreamReader("ogrenci.xml"))
            {
                XmlSerializer serilestirici = new XmlSerializer(typeof(Ogrenci));
                Ogrenci ogr =(Ogrenci)serilestirici.Deserialize(sr);
                return ogr;
            }
        }
    }
    [Serializable]
    public class Ogrenci
    {
        public string isim;
        public string soyisim;
        [NonSerialized]
        [XmlIgnore]
        public int yas;
    }
}
