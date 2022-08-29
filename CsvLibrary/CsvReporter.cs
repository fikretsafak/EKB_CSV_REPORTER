using Entities;
using System;
using System.IO;


namespace CsvLibrary
{
    public class CsvReporter
    {
        bool sfkIsNew = false;
        

        string sfkPath = @"C:\Users\Public\Documents\Reports_ekb\";


        public void CreateSfkFile()
        {
            using (StreamWriter writer = new StreamWriter(sfkPath + $"EKB_KARAKURTHES_{DateTime.Now.Date.ToString("yyyyMMdd")}.csv", true))
            {
                writer.WriteLine("SANTRAL ADI:;KARAKURT BARAJI VE HES(BILSEV)");
                writer.WriteLine("FREKANS KONTROLUNE KATILAN BIRIMIN ADI:; KARAKURT BARAJI VE HES(BILSEV)");
                writer.WriteLine("FREKANS KONTROLUNE KATILAN BIRIMIN (UEVCB YA DA AGC'DEN REFERANS DEGER GELEN BIRIM) (SANTRAL/KOMBINE CEVRIM BLOGU/UNITE) NOMINAL AKTIF GUCU (KURULU GUCU) (MW):; 96,99");
                writer.WriteLine("ILGILI BIRIMIN AKTIF UNITELERININ PRIMER FREKANS KONTROLU ICIN GECERLI DROOP DEGERLERI (%):;4;4");
                writer.WriteLine("ILGILI BIRIMIN AKTIF UNITELERININ GECERLI DROOP DEGERLERI ILE, 200 mHz'LIK BASAMAK FREKANS DEGISIMINE VERDIGI TEPKININ ORTALAMA DENGEYE GELME SURESI (sn):;43;43");
                writer.WriteLine("ILGILI BIRIMIN AKTIF UNITELERININ YUK ALMA - ATMA HIZLARI (MW/dak):;13,8;15,4");
                writer.WriteLine("ILGILI BIRIMIN AKTIF UNITELERININ HIZ REGULATORUNE GIDEN HIZ BILGISINDEKI +/- ISTEKSEL OLU-BAND DEGERI (mHz):;0;0");
                writer.WriteLine("TARIH;SAAT;SIRA_NO;FRE_HZ;BRM_GUC_REF_DEG_MW;BRM_AKT_CIK_GUCU_BRUTMW;BRM_AKT_CIK_GUCU_NETMW;BRM_PFK_TPLM_NOM_GUCMW;BRM_SEK_MAK_MW;BRM_SEK_MIN_MW;BRM_PRI_MAKC_MW;BRM_PRI_MINC_MW;BRM_GNCL_KPR_MW/HZ;BRM_SFK_REZ_MIK_MW;BRM_PFK_REZ_MIK_MW;AGC_AKT;PFCO_AKT");
            }
        }


        public bool WriteSfkData(SfkReport sfkReport, int counter)
        {

            if (!File.Exists(sfkPath + $"EKB_KARAKURTHES_{DateTime.Now.Date.ToString("yyyyMMdd")}.csv"))
            {
                CreateSfkFile();
                sfkIsNew = true;
                counter = 0;
            }

            using (StreamWriter writer = new StreamWriter(sfkPath + $"EKB_KARAKURTHES_{DateTime.Now.Date.ToString("yyyyMMdd")}.csv", true))
            {

                writer.WriteLine(DateTime.Now.ToString("dd.MM.yyyy") + ";" + DateTime.Now.ToString("HH:mm:ss") + ";" + counter.ToString() + ";" + sfkReport.FRE_HZ.ToString("0.000") + ";" +
                    sfkReport.BRM_GUC_REF_DEG_MW.ToString("0.000") + ";" + sfkReport.BRM_AKT_CIK_GUCU_BRUTMW.ToString("0.000") + ";" + sfkReport.BRM_AKT_CIK_GUCU_NETMW.ToString("0.000") + ";" + sfkReport.BRM_PFK_TPLM_NOM_GUCMW.ToString("0.000") + ";" +
                    sfkReport.BRM_SEK_MAK_MW.ToString("0.000") + ";" + sfkReport.BRM_SEK_MIN_MW.ToString("0.000") + ";" + sfkReport.BRM_PRI_MAKC_MW.ToString("0.000") + ";" + sfkReport.BRM_PRI_MINC_MW.ToString("0.000") + ";" +
                    sfkReport.BRM_GNCL_KPR_MW_HZ.ToString("0.000") + ";" + sfkReport.BRM_SFK_REZ_MIK_MW.ToString("0.000") + ";" + sfkReport.BRM_PFK_REZ_MIK_MW.ToString("0.000") + ";" +
                    sfkReport.AGC_AKT.ToString("0") + ";" + sfkReport.PFCO_AKT.ToString("0"));
            }

            if (sfkIsNew)
            {
                sfkIsNew = false;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
