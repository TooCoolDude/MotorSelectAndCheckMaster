﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid.IO;
using unvell.ReoGrid;

namespace CurseDeliverer
{
    public static class VariantReader
    {
        public static VariantValues[] GetVariants()
        {
            var path = @"E:\Curse1\auto\Variants.xlsx";
            var workbook = ReoGridControl.CreateMemoryWorkbook();
            workbook.Load(path, FileFormat.Excel2007);
            var sheet1 = workbook.Worksheets[0];

            var variants = new List<VariantValues>();

            for (int i = 4; i < 14; i++)
            {
                for (int j = 4; j < 14; j++)
                {
                    var variant = new VariantValues
                        (
                            Variant: (i-3).ToString()+(j-3).ToString(),
                            P1: sheet1.GetCellData<double>("B" + i), 
                            P2: sheet1.GetCellData<double>("C" + i),
                            P3: sheet1.GetCellData<double>("D" + i),
                            P4: sheet1.GetCellData<double>("E" + i),
                            t1: sheet1.GetCellData<double>("G" + i),
                            t2: sheet1.GetCellData<double>("H" + i),
                            t3: sheet1.GetCellData<double>("I" + i),
                            t4: sheet1.GetCellData<double>("J" + i)
                        );

                    variants.Add(variant);
                }
            }

            return variants.ToArray();
        }
    }
}
