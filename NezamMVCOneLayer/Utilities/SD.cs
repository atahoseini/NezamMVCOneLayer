using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NezamMVCOneLayer.Utilities
{
    public static class SD
    {
        public static readonly IList<String> ListOFFirstName = new ReadOnlyCollection<string>
        (
            new List<String>
                {
                    "محمد", 
                    "علی",
                    "رضا", 
                    "جعفر", 
                    "هادی",
                    "مصطفی",
                    "آرش", 
                    "میلاد",
                    "مرتضی", 
                    "بابک", 
                    "جواد",
                    "فرهاد",
                    "اصغر",
                    "سعید",
                    "فردین",
                    "فرزین",
                    "فرشید",
                    "فرید",
                    "مهیار",
                    "عطا",
                    "بهزاد",
                }
        );

        public static readonly IList<String> ListOFFamily = new ReadOnlyCollection<string>
        (
            new List<String>
                {
                            "محمدی",
                            "علی نیا",
                            "رضا زاده",
                            "جعفری",
                            "مهدوی",
                            "مصطفی پور",
                            "مشیری",
                            "نوری",
                            "مرتضوی",
                            "خرم",
                            "جوادی",
                            "فرهادی",
                            "اصغرزاده",
                            "سعیدنیا",
                            "قهرمانی",
                            "فرزین",
                            "حیدری",
                            "واسع",
                            "حسینی",
                            "مجیدی",
                            "هاشمی",
                }
        );


        public static readonly IList<int> ListOFSHSH = new ReadOnlyCollection<int>
        (
            new List<int>
                {
                        1200,
                        1425,
                        9859,
                        25362,
                        25,
                        7,
                        7890,
                        650120,
                        1,
                        0,
                        20,
                        30,
                        1578,
                        259457,
                        3,
                        8,
                        726,
                        954,
                        765,
                        65410,
                        1206,
                        231,
                        12,
                        1363,
                        1365,
                        1425,
                        442515
                }
        );
    }
}
