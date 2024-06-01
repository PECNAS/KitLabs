using WebApplication1.Models;

namespace WebApplication1
{
    public class SampleData
    {
        public static void Initialize(MobileContext context, IWebHostEnvironment env)
        {
            if (!context.Items.Any())
            {
                context.Items.AddRange(
                new Item
                {
                    Title = "AMD Ryzen 9 5950X",
                    Description = "Центральный процессор",
                    Price = 27314,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Intel Core i9-12900K",
                    Description = "Центральный процессор",
                    Price = 19852,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Apple M1 Pro",
                    Description = "Центральный процессор",
                    Price = 33647,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Ryzen 7 5800X",
                    Description = "Центральный процессор",
                    Price = 15209,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Intel Core i7-12700K",
                    Description = "Центральный процессор",
                    Price = 30181,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Ryzen 5 5600X",
                    Description = "Центральный процессор",
                    Price = 24795,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Intel Core i5-12600K",
                    Description = "Центральный процессор",
                    Price = 34962,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Qualcomm Snapdragon 8cx Gen 3",
                    Description = "Центральный процессор",
                    Price = 21438,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "MediaTek Dimensity 1200",
                    Description = "Центральный процессор",
                    Price = 28506,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Intel Core i3-12100",
                    Description = "Центральный процессор",
                    Price = 16731,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Ryzen 3 3300X",
                    Description = "Центральный процессор",
                    Price = 32084,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Intel Core i9-11900K",
                    Description = "Центральный процессор",
                    Price = 25617,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Intel Core i5-11600K",
                    Description = "Центральный процессор",
                    Price = 14390,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Ryzen Threadripper 3990X",
                    Description = "Центральный процессор",
                    Price = 23259,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Apple M1 Max",
                    Description = "Центральный процессор",
                    Price = 29873,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce RTX 3090",
                    Description = "Видеокарта",
                    Price = 37142,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce RTX 3080",
                    Description = "Видеокарта",
                    Price = 28695,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce RTX 3070",
                    Description = "Видеокарта",
                    Price = 52381,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce RTX 3060 Ti",
                    Description = "Видеокарта",
                    Price = 43857,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Radeon RX 6900 XT",
                    Description = "Видеокарта",
                    Price = 24013,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Radeon RX 6800 XT",
                    Description = "Видеокарта",
                    Price = 49526,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Radeon RX 6700 XT",
                    Description = "Видеокарта",
                    Price = 31784,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce RTX 2080 Ti",
                    Description = "Видеокарта",
                    Price = 45290,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce RTX 2070 Super",
                    Description = "Видеокарта",
                    Price = 39861,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce GTX 1660 Super",
                    Description = "Видеокарта",
                    Price = 22468,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Radeon RX 5700 XT",
                    Description = "Видеокарта",
                    Price = 50932,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Radeon RX 5600 XT",
                    Description = "Видеокарта",
                    Price = 35179,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce GTX 1650 Super",
                    Description = "Видеокарта",
                    Price = 47605,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "NVIDIA GeForce GT 1030",
                    Description = "Видеокарта",
                    Price = 26734,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "AMD Radeon RX 5500 XT",
                    Description = "Видеокарта",
                    Price = 41328,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Kingston HyperX Fury DDR4-3200 16GB (2x8GB) CL16 - комплект из двух модулей по 8 ГБ, частота 3200 МГц, тайминги CL16, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 9184,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Corsair Vengeance LPX DDR4-3600 32GB (2x16GB) CL18 - комплект из двух модулей по 16 ГБ, частота 3600 МГц, тайминги CL18, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 9485,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "G.Skill Trident Z Neo DDR4-3600 64GB (4x16GB) CL16 - комплект из четырех модулей по 16 ГБ, частота 3600 МГц, тайминги CL16, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 4555,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Crucial Ballistix RGB DDR4-3200 16GB (2x8GB) CL16 - комплект из двух модулей по 8 ГБ с RGB-подсветкой, частота 3200 МГц, тайминги CL16, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 7312,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Team T-Force Night Hawk RGB DDR4-3200 16GB (2x8GB) CL16 - комплект из двух модулей по 8 ГБ с RGB-подсветкой, частота 3200 МГц, тайминги CL16, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 9876,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Patriot Viper Steel DDR4-4400 16GB (2x8GB) CL19 - комплект из двух модулей по 8 ГБ, частота 4400 МГц, тайминги CL19, напряжение 1.45В.",
                    Description = "Оперативная память",
                    Price = 12333,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "HyperX Predator DDR4-3600 32GB (4x8GB) CL17 - комплект из четырех модулей по 8 ГБ, частота 3600 МГц, тайминги CL17, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 4224,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Corsair Dominator Platinum RGB DDR4-3200 32GB (4x8GB) CL16 - комплект из четырех модулей по 8 ГБ с RGB-подсветкой, частота 3200 МГц, тайминги CL16, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 8654,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Crucial Ballistix MAX DDR4-4000 16GB (2x8GB) CL18 - комплект из двух модулей по 8 ГБ, частота 4000 МГц, тайминги CL18, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 1235,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "G.Skill Ripjaws V DDR4-3200 32GB (2x16GB) CL16 - комплект из двух модулей по 16 ГБ, частота 3200 МГц, тайминги CL16, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 8553,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ADATA XPG Spectrix D60G DDR4-3200 32GB (2x16GB) CL16 - комплект из двух модулей по 16 ГБ с RGB-подсветкой, частота 3200 МГц, тайминги CL16, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 9866,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Patriot Viper RGB DDR4-3600 16GB (2x8GB) CL18 - комплект из двух модулей по 8 ГБ с RGB-подсветкой, частота 3600 МГц, тайминги CL18, напряжение 1.35В.",
                    Description = "Оперативная память",
                    Price = 3998,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Team T-Create Classic DDR4-3200 32GB (2x16GB) CL22 - комплект из двух модулей по 16 ГБ, частота 3200 МГц, тайминги CL22, напряжение 1.20В.",
                    Description = "Оперативная память",
                    Price = 4156,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Kingston HyperX Impact DDR4-2666 32GB (2x16GB) CL15 - комплект из двух модулей SO-DIMM по 16 ГБ для ноутбуков, частота 2666 МГц, тайминги CL15, напряжение 1.20В.",
                    Description = "Оперативная память",
                    Price = 5375,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Crucial CT2K32G4SFD832A DDR4-3200 64GB (2x32GB) CL22 - комплект из двух серверных модулей по 32 ГБ, частота 3200 МГц, тайминги CL22, напряжение 1.20В, поддержка ECC.",
                    Description = "Оперативная память",
                    Price = 11953,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ASUS ROG Strix GL12CX",
                    Description = "Системный блок",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Dell XPS 8930",
                    Description = "Системный блок",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "HP OMEN Obelisk",
                    Description = "Системный блок",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "CyberPowerPC Gamer Xtreme VR",
                    Description = "Системный блок",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Corsair Vengeance i7200",
                    Description = "Системный блок",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "EVGA SuperNOVA 750 G5",
                    Description = "Блок питания",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Corsair RM750x",
                    Description = "Блок питания",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Seasonic Focus GX-650",
                    Description = "Блок питания",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "be quiet! Straight Power 11",
                    Description = "Блок питания",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Thermaltake Toughpower GF1",
                    Description = "Блок питания",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "MSI MPG Z490 Gaming Edge WiFi",
                    Description = "Материнская плата",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ASUS ROG Strix X570 - E Gaming",
                    Description = "Материнская плата",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Gigabyte B550 AORUS PRO",
                    Description = "Материнская плата",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ASRock B550M Steel Legend",
                    Description = "Материнская плата",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ASUS TUF Gaming B550M - PLUS",
                    Description = "Материнская плата",
                    Price = 10000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                }, new Item
                {
                    Title = "Creative Sound Blaster Z",
                    Description = "Звуковая карта",
                    Price = 5000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ASUS Xonar AE",
                    Description = "Звуковая карта",
                    Price = 5000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Focusrite Scarlett 2i2",
                    Description = "Звуковая карта",
                    Price = 5000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Creative Sound BlasterX G6",
                    Description = "Звуковая карта",
                    Price = 5000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ASUS Strix Raid DLX",
                    Description = "Звуковая карта",
                    Price = 5000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "ASUS TUF Gaming VG27AQ",
                    Description = "Монитор",
                    Price = 6000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "LG 27GL850-B",
                    Description = "Монитор",
                    Price = 6000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Dell S2719DGF",
                    Description = "Монитор",
                    Price = 6000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Samsung Odyssey G7",
                    Description = "Монитор",
                    Price = 6000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "BenQ EX2780Q",
                    Description = "Монитор",
                    Price = 6000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Corsair K95 RGB Platinum XT",
                    Description = "Клавиатура",
                    Price = 2500,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Razer Huntsman Elite",
                    Description = "Клавиатура",
                    Price = 2500,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Logitech G Pro X",
                    Description = "Клавиатура",
                    Price = 2500,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "SteelSeries Apex Pro",
                    Description = "Клавиатура",
                    Price = 2500,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "HyperX Alloy Origins",
                    Description = "Клавиатура",
                    Price = 2500,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Logitech G502 HERO",
                    Description = "Компьютерная мышь",
                    Price = 2000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Razer DeathAdder Elite",
                    Description = "Компьютерная мышь",
                    Price = 2000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "SteelSeries Rival 600",
                    Description = "Компьютерная мышь",
                    Price = 2000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Corsair Dark Core RGB",
                    Description = "Компьютерная мышь",
                    Price = 2000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                },
                new Item
                {
                    Title = "Zowie EC Series",
                    Description = "Компьютерная мышь",
                    Price = 2000,
                    Image = "/imgs/img1.jpg",
                    Rating = 5.0
                }

                );
                context.SaveChanges();
            }
        }
    }
}
