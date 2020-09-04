using Phones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phones.Data
{
    public class DbInitializer
    {
        public static void Initialize(PhonesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Producers.Any())
            {
                return;
            }

            var producers = new Producer[]
            {
                new Producer { ProducerName = "Sony", ProducerCountry = "Japan" },
                new Producer { ProducerName = "Samsung", ProducerCountry = "South Korea" },
                new Producer { ProducerName = "Nokia", ProducerCountry = "Finland" },
                new Producer { ProducerName = "IPhone", ProducerCountry = "USA" },
            };

            foreach (Producer p in producers)
            {
                context.Producers.Add(p);
            }
            context.SaveChanges();

            var phones = new Phone[]
            {
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Sony").Id, Name = "Xperia Z1 compact",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 16.25m, OperatingSystem = "Android 4.3 (Jelly Bean)",
                    Price = 500m, ImgUrl = "images/mobile1.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Sony").Id, Name = "Xperia XZ2",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 16.25m, OperatingSystem = "Android 10, New Android",
                    Price = 1300m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Sony").Id, Name = "Xperia XZ3",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 16.25m, OperatingSystem = "Android 10, New Android",
                    Price = 1500m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Sony").Id, Name = "Xperia Z1 mini",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 16.25m, OperatingSystem = "Android 4.3 (Jelly Bean)",
                    Price = 500m, ImgUrl = "images/mobile1.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Sony").Id, Name = "Xperia Z4",
                    Size = "140 x 64.9 x 9.5 mm", Weight = 200, ScreenSize = 5.3m, ScreenDepth = 200,
                    Processor = "Snapdragon 800 (28 nm)", Storage = 32.25m, OperatingSystem = "Android 4.3 (Jelly Bean)",
                    Price = 700m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "IPhone").Id, Name = "Iphone X",
                    Size = "143.6 x 70.9 x 7.7 mm", Weight = 325, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 64.55m, OperatingSystem = "iOS 11.1.1",
                    Price = 542m, ImgUrl = "images/mobile2.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "IPhone").Id, Name = "Iphone 11 Pro",
                    Size = "143.6 x 70.9 x 7.7 mm", Weight = 325, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 64.55m, OperatingSystem = "iOS 12.1.4",
                    Price = 3542m, ImgUrl = "images/mobile2.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "IPhone").Id, Name = "Iphone 11",
                    Size = "143.6 x 70.9 x 7.7 mm", Weight = 325, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 64.55m, OperatingSystem = "iOS 12.1.1",
                    Price = 2542m, ImgUrl = "images/mobile2.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "IPhone").Id, Name = "Iphone XS",
                    Size = "143.6 x 70.9 x 7.7 mm", Weight = 325, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 64.55m, OperatingSystem = "iOS 11.1.1",
                    Price = 542m, ImgUrl = "images/mobile2.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Samsung").Id, Name = "Galaxy S20",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm SM8250 Snapdragon 865 (7 nm+)", Storage = 16.25m, OperatingSystem = "Android 10, One UI 2.5",
                    Price = 300m, ImgUrl = "images/mobile1.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Samsung").Id, Name = "Galaxy S10",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm SM8250 Snapdragon 865 (7 nm+)", Storage = 16.25m, OperatingSystem = "Android 10, One UI 2.5",
                    Price = 1200m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Samsung").Id, Name = "Galaxy S9",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 16.25m, OperatingSystem = "Android 8.3 (Tasty Bean)",
                    Price = 484.55m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Samsung").Id, Name = "Galaxy M31S",
                    Size = "159.3 x 74.4 x 9.3 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 300,
                    Processor = "Exynos 9611 (10nm)", Storage = 64.25m, OperatingSystem = "Android 10, One UI 2.0",
                    Price = 2484.55m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Samsung").Id, Name = "Galaxy D32B",
                    Size = "149.3 x 74.4 x 9.3 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 300,
                    Processor = "Exynos 9611 (10nm)", Storage = 64.25m, OperatingSystem = "Android 10, One UI 2.0",
                    Price = 1484.25m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Samsung").Id, Name = "Galaxy F20",
                    Size = "132.3 x 74.4 x 9.3 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 300,
                    Processor = "Exynos 9611 (10nm)", Storage = 64.25m, OperatingSystem = "Android 11, One UI 2.0",
                    Price = 2484.55m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Nokia").Id, Name = "C1",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 16.25m, OperatingSystem = "Android 10, Android One",
                    Price = 300m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Nokia").Id, Name = "C4",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm MSM8974 Snapdragon 800 (28 nm)", Storage = 16.25m, OperatingSystem = "Android 10, Android One",
                    Price = 706m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Nokia").Id, Name = "C2",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm SDM765 Snapdragon 765G (7 nm)", Storage = 16.25m, OperatingSystem = "Android 10, Android One",
                    Price = 825.25m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Nokia").Id, Name = "C5",
                    Size = "117 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 5.3m, ScreenDepth = 122,
                    Processor = "Qualcomm SDM765 Snapdragon 765G (7 nm)", Storage = 16.25m, OperatingSystem = "Android 3, Android eight",
                    Price = 125m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Nokia").Id, Name = "X71",
                    Size = "127 x 64.9 x 9.5 mm", Weight = 137, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm SDM765 Snapdragon 765G (7 nm)", Storage = 16.25m, OperatingSystem = "Android 9, Android three",
                    Price = 450m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                },
                new Phone
                {
                    ProducerId = producers.Single(p => p.ProducerName == "Nokia").Id, Name = "X72",
                    Size = "120 x 64.9 x 9.5 mm", Weight = 150, ScreenSize = 4.3m, ScreenDepth = 122,
                    Processor = "Qualcomm SDM765 Snapdragon 765G (7 nm)", Storage = 32m, OperatingSystem = "Android 7, Android three",
                    Price = 350m, ImgUrl = "images/default.png", VidUrl = "https://somevidurl.com/"
                }
            };

            foreach (Phone p in phones)
            {
                context.Phones.Add(p);
            }
            context.SaveChanges();
        }
    }
}
