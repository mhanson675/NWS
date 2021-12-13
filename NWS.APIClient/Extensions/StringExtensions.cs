using System.Linq;

#pragma warning disable CS1591

namespace NWS.APIClient.Extensions
{
    public static class StringExtensions
    {
        private static readonly string[] validWFOList = new string[]
        {
            "AKQ", "ALY", "BGM", "BOX", "BTV", "BUF", "CAE", "CAR", "CHS", "CLE", "CTP", "GSP", "GYX", "ILM", "ILN", "LWX", "MHX", "OKX", "PBZ", "PHI", "RAH",
            "RLX", "RNK", "ABQ", "AMA", "BMX", "BRO", "CRP", "EPZ", "EWX", "FFC", "FWD", "HGX", "HUN", "JAN", "JAX", "KEY", "LCH", "LIX", "LUB", "LZK", "MAF",
            "MEG", "MFL", "MLB", "MOB", "MRX", "OHX", "OUN", "SHV", "SJT", "SJU", "TAE", "TBW", "TSA", "ABR", "APX", "ARX", "BIS", "BOU", "CYS", "DDC", "DLH",
            "DMX", "DTX", "DVN", "EAX", "FGF", "FSD", "GID", "GJT", "GLD", "GRB", "GRR", "ICT", "ILX", "IND", "IWX", "JKL", "LBF", "LMK", "LOT", "LSX", "MKX",
            "MPX", "MQT", "OAX", "PAH", "PUB", "RIW", "SGF", "TOP", "UNR", "BOI", "BYZ", "EKA", "FGZ", "GGW", "HNX", "LKN", "LOX", "MFR", "MSO", "MTR", "OTX",
            "PDT", "PIH", "PQR", "PSR", "REV", "SEW", "SGX", "SLC", "STO", "TFX", "TWC", "VEF", "AER", "AFC", "AFG", "AJK", "ALU", "GUM", "HPA", "HFO", "PPG",
            "STU", "NH1", "NH2", "ONA", "ONP"
        };

        private static readonly string[] validStateList = new string[]
        {
            "AL", "AK", "AS", "AR", "AZ", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI",
            "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VI",
            "VA", "WA", "WV", "WI", "WY"
        };

        /// <summary>
        /// Determines whether a string is a valid WeatherForecast Office Id. Based on the list of WFO Ids provided by the API.
        /// </summary>
        /// <param name="wfo">The three character WeatherForecast Office Id.</param>
        /// <returns>
        ///   <c>true</c> If the string is valid wfo; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidWFO(this string wfo)
        {
            return !string.IsNullOrWhiteSpace(wfo) && validWFOList.Contains(wfo.ToUpper());
        }

        public static bool IsValidState(this string state)
        {
            return !string.IsNullOrWhiteSpace(state) && validStateList.Contains(state.ToUpper());
        }
    }

    //public static bool IsValidTimeFormat(this string time)
    //{
    //    var Month8601 = new Regex(@"/^([0 - 9]{ 4})-(1[0 - 2] | 0[1 - 9])$");
    //}
}

#pragma warning restore CS1591