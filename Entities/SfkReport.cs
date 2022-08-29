using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SfkReport
    {
        public float FRE_HZ { get; set; }
        public float BRM_GUC_REF_DEG_MW { get; set; }
        public float BRM_AKT_CIK_GUCU_BRUTMW { get; set; }
        public float BRM_AKT_CIK_GUCU_NETMW { get; set; }
        public float BRM_PFK_TPLM_NOM_GUCMW { get; set; }
        public float BRM_SEK_MAK_MW { get; set; }
        public float BRM_SEK_MIN_MW { get; set; }
        public float BRM_PRI_MAKC_MW { get; set; }
        public float BRM_PRI_MINC_MW { get; set; }
        public float BRM_GNCL_KPR_MW_HZ { get; set; }
        public float BRM_SFK_REZ_MIK_MW { get; set; }
        public float BRM_PFK_REZ_MIK_MW { get; set; }
        public int AGC_AKT { get; set; }
        public int PFCO_AKT { get; set; }
    }
}
