namespace Cake.Mage
{
    /// <summary>
    /// Enum TrustLevel
    /// </summary>
    public enum TrustLevel
    {
        /// <summary>
        /// Assigned a trust level based on the zone in which their URL resides
        /// </summary>
        Default,

        /// <summary>
        /// Internet trust level
        /// </summary>
        Internet,

        /// <summary>
        /// Intranet trust level
        /// </summary>
        Intranet,

        /// <summary>
        /// Full trust level
        /// </summary>
        FullTrust
    }
}