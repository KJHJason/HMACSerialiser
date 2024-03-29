﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HMACSerialiser.Base64Encoders;
using HMACSerialiser.KFD;
using System.Text;
using HMACSerialiser.HMAC;

namespace HKDFTests
{
    [TestClass]
    public class BigKeyTests : BaseTestClass
    {
        [TestMethod]
        public void BigKeyTest()
        {
            byte[] ikm = Encoding.UTF8.GetBytes("e064a8ca0802224cbeec061a57cd955f772be06444ab02b734c2f73b3754cace73d349371186bf414c90eada277b207e92e2b77819d5cc56cb163c2331da81e6300e30e75ef0372c6698375dc894c52cc55f2def27a52f6b9e24eea334448c97c9af5e366504d2d95b66ac0f8c8ab645365517bbff39eed0fe0ee564572ba032ff885a2794170e423bd624a1b89a867d4276155562c1d9459881469b10e798789f541ed445cb795245a13f312381145ac6db7b773aded62a038a72a1c3241f386202210af4d6c4fcee1e465c471a1f0104d636e3552a63f65469d0a84af2c805f5d2b33a6926d5790c9184691843d359cafee2417618fc15348fa7154ce09cb332eadca64c2812273a72bba6f6762aa09f36c5f1cf51fb499c287359a957671b03690e050a15163b437d6b9be386a38a3854c391ae733b1537b3d908894b8ab00ae71785305e050807f3c2020aa318a8c45b03eeabc6a53f62b51327c5a551c981bde9c1a9e6b1b88a8414b156c3d79855702735675229c56c1b7e722ba42794bfa6c7e403e9743bc6747a5d4fda5c9dbb79b56555f69b855f52ec093914f7702f78eee7d7617a3f4864677025e16f6a197827ca9b05ec28aed74867608d7dd63da87bc09917ef9b4d7b1688591d665c194f156912d3efcee980603c347311663ade4d4f26a8046fc68e35d06f9ce8c61779e29931c321ebb1441d67336d06438deaeefd76ca91b40792b005c78670df11976d0fd353768c7acf22197b8d111915dde389c9390d5d60d2d2fa32f7e250a657aa16a9ca01a9cb62a7e3924dc7b61040f922b740b9dc9c96f1067b1fb1904bf8ee915816bd88839c03907d46d348ec2ed75bd505a356d74ae6183a29eb011e09c0e5e4a18dc706f00560d16716722569e987c2f99bc69bd80d04a4f1d768e31ed3522b5cdf346c38bffb720c676f7b2cc04d1395a378020d3aabbcec6b20fb53e30ef62968d08186736ae0711fcafdadab3e147b5c64364729f207ff7e253bc838f87e0bb7df63d03e42aef1d827836d3743af42081c15da84dbbd8eaa51af3d36e5b84d337ed7598803aa9deef2d6beb6711f12bc132d59bd3f05e50d97a6b48b4952a811aad3c65eef891eb996ee1bb753eec98f6c6c90c6d891b4107392a105c03cf4a4c9dfaaadcdd49b3692c5a2a0f8f7cd8b4f352c2f3bda16e7f43f58bcc80e26b4aefbebf2ebb67c9f98c3f4079c6021faf2a006a1c09455f42bda09ec961bcb8afc0318f4a98a5386eb1ade082a1776c38b808ec9f2c59c3a0b24e4b4467a0fcfdb21775e2a9dd1621f8137e33961496b801d14534271787459b587e661e66b89f31ef748d8f164b706a12892556bf4ff2b66ab0749edbcd6ea53f6f962365003c6e40aa3cd48cf8cad7da41fead5e19f73");
            byte[] salt = null;
            byte[] info = null;
            int len = 64;
            var expectedOutputs = new string[] 
            {
                // SHA1
                "HJUtmQOEoizG55j5NaciQiWj7l+L2iO4t53dLl0OcNHomNdulCKsVKvWeR9sGHutJfzi2noxOb8PV4NxbflJQA",
                // SHA256
                "Wke0fZDymADHJihbD5Du8uHqo/tEvxgbBUXsbKPLqfwhcKg6oxjb59Tgg9EOXLX72HSRr1fjrn+M70Knc2l22A",
                // SHA384
                "rR04Dv5DmXrBdqwp5TUlFX3bVAwnFtUjyMjp62Yg38cU1IFJOOyqyRQjVAUamuApM0rPg4S5bg7HHDT9GP0eag",
                // SHA512
                "xKCFxM9b4esbu6gXE+r548nC97Np0CqGLTbxtm2NSav01rzYBm90oO+Pd6UZLuO86IAZdF/+cDQgsmKvM2EhDQ",
            };
            TestOutputs(ikm, salt, info, len, expectedOutputs);
        }

        [TestMethod]
        public void BigKeyTestWithSalt()
        {
            byte[] ikm = Encoding.UTF8.GetBytes("e064a8ca0802224cbeec061a57cd955f772be06444ab02b734c2f73b3754cace73d349371186bf414c90eada277b207e92e2b77819d5cc56cb163c2331da81e6300e30e75ef0372c6698375dc894c52cc55f2def27a52f6b9e24eea334448c97c9af5e366504d2d95b66ac0f8c8ab645365517bbff39eed0fe0ee564572ba032ff885a2794170e423bd624a1b89a867d4276155562c1d9459881469b10e798789f541ed445cb795245a13f312381145ac6db7b773aded62a038a72a1c3241f386202210af4d6c4fcee1e465c471a1f0104d636e3552a63f65469d0a84af2c805f5d2b33a6926d5790c9184691843d359cafee2417618fc15348fa7154ce09cb332eadca64c2812273a72bba6f6762aa09f36c5f1cf51fb499c287359a957671b03690e050a15163b437d6b9be386a38a3854c391ae733b1537b3d908894b8ab00ae71785305e050807f3c2020aa318a8c45b03eeabc6a53f62b51327c5a551c981bde9c1a9e6b1b88a8414b156c3d79855702735675229c56c1b7e722ba42794bfa6c7e403e9743bc6747a5d4fda5c9dbb79b56555f69b855f52ec093914f7702f78eee7d7617a3f4864677025e16f6a197827ca9b05ec28aed74867608d7dd63da87bc09917ef9b4d7b1688591d665c194f156912d3efcee980603c347311663ade4d4f26a8046fc68e35d06f9ce8c61779e29931c321ebb1441d67336d06438deaeefd76ca91b40792b005c78670df11976d0fd353768c7acf22197b8d111915dde389c9390d5d60d2d2fa32f7e250a657aa16a9ca01a9cb62a7e3924dc7b61040f922b740b9dc9c96f1067b1fb1904bf8ee915816bd88839c03907d46d348ec2ed75bd505a356d74ae6183a29eb011e09c0e5e4a18dc706f00560d16716722569e987c2f99bc69bd80d04a4f1d768e31ed3522b5cdf346c38bffb720c676f7b2cc04d1395a378020d3aabbcec6b20fb53e30ef62968d08186736ae0711fcafdadab3e147b5c64364729f207ff7e253bc838f87e0bb7df63d03e42aef1d827836d3743af42081c15da84dbbd8eaa51af3d36e5b84d337ed7598803aa9deef2d6beb6711f12bc132d59bd3f05e50d97a6b48b4952a811aad3c65eef891eb996ee1bb753eec98f6c6c90c6d891b4107392a105c03cf4a4c9dfaaadcdd49b3692c5a2a0f8f7cd8b4f352c2f3bda16e7f43f58bcc80e26b4aefbebf2ebb67c9f98c3f4079c6021faf2a006a1c09455f42bda09ec961bcb8afc0318f4a98a5386eb1ade082a1776c38b808ec9f2c59c3a0b24e4b4467a0fcfdb21775e2a9dd1621f8137e33961496b801d14534271787459b587e661e66b89f31ef748d8f164b706a12892556bf4ff2b66ab0749edbcd6ea53f6f962365003c6e40aa3cd48cf8cad7da41fead5e19f73");
            byte[] salt = Encoding.UTF8.GetBytes("custom.salt!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            byte[] info = null;
            int len = 64;
            var expectedOutputs = new string[] 
            {
                // SHA1
                "iwfbEhqEtz7vZee8pu5zkqo18X/Nfc9ZKHnxbxRhREDjaImmItCHPynQ27O4t7q2hsrZbsLcPDTLOtQ99bQjPw",
                // SHA256
                "QLpQxBIqFzsowou5i4tlxZaU79i/TgcN6Bu2oNzr3NG14HVZh0+UOHim9Tg0hz+cZEsP+btgF2EEpUy3uWsDkg",
                // SHA384
                "M/CJlBKOqE5/o6zz4IqBH3Bwer7W7u/HM/4kSaTRA7zEDoZe0P3JguiKa0hvoorVmHWvltWOJeoQCB32wkE6Og",
                // SHA512
                "HKdFaD+Ay1EMYdfzHcSe77VJmUiqctt5MS4yRoSWVM4CIEVC1wr5ps/EyV3gwrfG//Jk4Hr+IXQr+gj4KeTS5Q",
            };
            TestOutputs(ikm, salt, info, len, expectedOutputs);
        }

        [TestMethod]
        public void BigKeyTestWithInfo()
        {
            byte[] ikm = Encoding.UTF8.GetBytes("e064a8ca0802224cbeec061a57cd955f772be06444ab02b734c2f73b3754cace73d349371186bf414c90eada277b207e92e2b77819d5cc56cb163c2331da81e6300e30e75ef0372c6698375dc894c52cc55f2def27a52f6b9e24eea334448c97c9af5e366504d2d95b66ac0f8c8ab645365517bbff39eed0fe0ee564572ba032ff885a2794170e423bd624a1b89a867d4276155562c1d9459881469b10e798789f541ed445cb795245a13f312381145ac6db7b773aded62a038a72a1c3241f386202210af4d6c4fcee1e465c471a1f0104d636e3552a63f65469d0a84af2c805f5d2b33a6926d5790c9184691843d359cafee2417618fc15348fa7154ce09cb332eadca64c2812273a72bba6f6762aa09f36c5f1cf51fb499c287359a957671b03690e050a15163b437d6b9be386a38a3854c391ae733b1537b3d908894b8ab00ae71785305e050807f3c2020aa318a8c45b03eeabc6a53f62b51327c5a551c981bde9c1a9e6b1b88a8414b156c3d79855702735675229c56c1b7e722ba42794bfa6c7e403e9743bc6747a5d4fda5c9dbb79b56555f69b855f52ec093914f7702f78eee7d7617a3f4864677025e16f6a197827ca9b05ec28aed74867608d7dd63da87bc09917ef9b4d7b1688591d665c194f156912d3efcee980603c347311663ade4d4f26a8046fc68e35d06f9ce8c61779e29931c321ebb1441d67336d06438deaeefd76ca91b40792b005c78670df11976d0fd353768c7acf22197b8d111915dde389c9390d5d60d2d2fa32f7e250a657aa16a9ca01a9cb62a7e3924dc7b61040f922b740b9dc9c96f1067b1fb1904bf8ee915816bd88839c03907d46d348ec2ed75bd505a356d74ae6183a29eb011e09c0e5e4a18dc706f00560d16716722569e987c2f99bc69bd80d04a4f1d768e31ed3522b5cdf346c38bffb720c676f7b2cc04d1395a378020d3aabbcec6b20fb53e30ef62968d08186736ae0711fcafdadab3e147b5c64364729f207ff7e253bc838f87e0bb7df63d03e42aef1d827836d3743af42081c15da84dbbd8eaa51af3d36e5b84d337ed7598803aa9deef2d6beb6711f12bc132d59bd3f05e50d97a6b48b4952a811aad3c65eef891eb996ee1bb753eec98f6c6c90c6d891b4107392a105c03cf4a4c9dfaaadcdd49b3692c5a2a0f8f7cd8b4f352c2f3bda16e7f43f58bcc80e26b4aefbebf2ebb67c9f98c3f4079c6021faf2a006a1c09455f42bda09ec961bcb8afc0318f4a98a5386eb1ade082a1776c38b808ec9f2c59c3a0b24e4b4467a0fcfdb21775e2a9dd1621f8137e33961496b801d14534271787459b587e661e66b89f31ef748d8f164b706a12892556bf4ff2b66ab0749edbcd6ea53f6f962365003c6e40aa3cd48cf8cad7da41fead5e19f73");
            byte[] salt = null;
            byte[] info = Encoding.UTF8.GetBytes("derived.key!!!!!!!!!!!!!!!!!!");
            int len = 64;
            var expectedOutputs = new string[] 
            {
                // SHA1
                "aJYd6yAvMhgbDclGEPlLOTGIumNOta2XIoHcWfGhZX35kr9k10lCSSq9kMBeHm6aXjAOGfBBxlAwUcNcSzwyzQ",
                // SHA256
                "RqtixLu98vE947awOHKfZbxGg5q491pvBJChwNlEGGNukqv4J8NnCf8vntK6AfK3wx6c26S317B9xYLnY2sHrg",
                // SHA384
                "g6PmQvmIIaGFHji1RqhXu77u7MFFjkc5wRpXe75TKB6Cuh94Qwek6DFe8yZmjPuu3NsOVaM/MX2a/rzZgh5buw",
                // SHA512
                "Bsp5WAe8I8cR/sDGVCWPReDH4HvaQmTZmKIH7rhBYjRAgx5oR+ueLWhc4LUnGjKojM8KyGiUmwmZ1JdxG5SV/A",
            };
            TestOutputs(ikm, salt, info, len, expectedOutputs);
        }

        [TestMethod]
        public void BigKeyTestWithSaltAndInfo()
        {
            byte[] ikm = Encoding.UTF8.GetBytes("e064a8ca0802224cbeec061a57cd955f772be06444ab02b734c2f73b3754cace73d349371186bf414c90eada277b207e92e2b77819d5cc56cb163c2331da81e6300e30e75ef0372c6698375dc894c52cc55f2def27a52f6b9e24eea334448c97c9af5e366504d2d95b66ac0f8c8ab645365517bbff39eed0fe0ee564572ba032ff885a2794170e423bd624a1b89a867d4276155562c1d9459881469b10e798789f541ed445cb795245a13f312381145ac6db7b773aded62a038a72a1c3241f386202210af4d6c4fcee1e465c471a1f0104d636e3552a63f65469d0a84af2c805f5d2b33a6926d5790c9184691843d359cafee2417618fc15348fa7154ce09cb332eadca64c2812273a72bba6f6762aa09f36c5f1cf51fb499c287359a957671b03690e050a15163b437d6b9be386a38a3854c391ae733b1537b3d908894b8ab00ae71785305e050807f3c2020aa318a8c45b03eeabc6a53f62b51327c5a551c981bde9c1a9e6b1b88a8414b156c3d79855702735675229c56c1b7e722ba42794bfa6c7e403e9743bc6747a5d4fda5c9dbb79b56555f69b855f52ec093914f7702f78eee7d7617a3f4864677025e16f6a197827ca9b05ec28aed74867608d7dd63da87bc09917ef9b4d7b1688591d665c194f156912d3efcee980603c347311663ade4d4f26a8046fc68e35d06f9ce8c61779e29931c321ebb1441d67336d06438deaeefd76ca91b40792b005c78670df11976d0fd353768c7acf22197b8d111915dde389c9390d5d60d2d2fa32f7e250a657aa16a9ca01a9cb62a7e3924dc7b61040f922b740b9dc9c96f1067b1fb1904bf8ee915816bd88839c03907d46d348ec2ed75bd505a356d74ae6183a29eb011e09c0e5e4a18dc706f00560d16716722569e987c2f99bc69bd80d04a4f1d768e31ed3522b5cdf346c38bffb720c676f7b2cc04d1395a378020d3aabbcec6b20fb53e30ef62968d08186736ae0711fcafdadab3e147b5c64364729f207ff7e253bc838f87e0bb7df63d03e42aef1d827836d3743af42081c15da84dbbd8eaa51af3d36e5b84d337ed7598803aa9deef2d6beb6711f12bc132d59bd3f05e50d97a6b48b4952a811aad3c65eef891eb996ee1bb753eec98f6c6c90c6d891b4107392a105c03cf4a4c9dfaaadcdd49b3692c5a2a0f8f7cd8b4f352c2f3bda16e7f43f58bcc80e26b4aefbebf2ebb67c9f98c3f4079c6021faf2a006a1c09455f42bda09ec961bcb8afc0318f4a98a5386eb1ade082a1776c38b808ec9f2c59c3a0b24e4b4467a0fcfdb21775e2a9dd1621f8137e33961496b801d14534271787459b587e661e66b89f31ef748d8f164b706a12892556bf4ff2b66ab0749edbcd6ea53f6f962365003c6e40aa3cd48cf8cad7da41fead5e19f73");
            byte[] salt = Encoding.UTF8.GetBytes("custom.salt!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            byte[] info = Encoding.UTF8.GetBytes("derived.key!!!!!!!!!!!!!!!!!!");
            int len = 64;
            var expectedOutputs = new string[] 
            {
                // SHA1
                "o6JPotQcpje9N97TSakx4uQDj6mM9uk9NvyTyp5nHj8RpDDjctqpYvYaxuaT0S2WI0b99uKt/3+jzgY9K2BQpA",
                // SHA256
                "O1sVsHjMcBF1Rb1Ct/HmMmi1RYwfKA5rSEb3V7OMpHfmh9y+pL3yGRRGBaL09patmYmv6r9bE++TlOE3/uEQRQ",
                // SHA384
                "sh9nBvK9v3Xl9Wv0Wa0CGMISXY081Ql0polu9wLyMnSeEomUv7utlDaKHI7GFlzZ23D3VHrnOr1/rH7eim8oDA",
                // SHA512
                "03exFA5mRAjfHc63izMncu1ved8KMbEe70/F2A9akYBFTEs72c6rP+ukz1DoZYUltP9vi9cwOkdlRvzhJNP71w",
            };
            TestOutputs(ikm, salt, info, len, expectedOutputs);
        }
    }
}
