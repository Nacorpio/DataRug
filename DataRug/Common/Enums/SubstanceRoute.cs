namespace DataRug.Common.Enums
{
    /// <summary>
    /// Represents a route of administration for a substance.
    /// </summary>
    public enum SubstanceRoute
    {
        /// <summary>
        /// Signifies that a substance route is undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Signifies that a substance can be administered orally.
        /// </summary>
        Oral = 1,

        /// <summary>
        /// Signifies that a substance can be administered nasally.
        /// </summary>
        Nasal = 2,

        /// <summary>
        /// Signifies that a substance can be administered rectally.
        /// </summary>
        Rectal = 3,

        /// <summary>
        /// Signifies that a substance can be administered intravenously.
        /// </summary>
        Intravenous = 4,

        /// <summary>
        /// Signifies that a substance can be administered intramuscularily.
        /// </summary>
        Intramuscular = 5,

        /// <summary>
        /// Signifies that a substance can be administered sublingually. 
        /// </summary>
        Sublingual = 6,

        /// <summary>
        /// Signifies that a substance can be administered by vaporization.
        /// </summary>
        Vaporized = 7,

        /// <summary>
        /// Signifies that a substance can be administered by smoking.
        /// </summary>
        Smoked = 8,
    }

}