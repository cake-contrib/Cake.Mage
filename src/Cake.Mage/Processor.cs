// ReSharper disable InconsistentNaming
namespace Cake.Mage
{
    /// <summary>
    /// Enum Processor
    /// </summary>
    public enum Processor
    {
        /// <summary>
        /// Neutral with respect to processor and bits-per-word.
        /// </summary>
        Msil,

        /// <summary>
        /// A 32-bit Intel processor, either native or in the Windows on Windows environment on a 64-bit platform (WOW64).
        /// </summary>
        X86,

        /// <summary>
        /// A 64-bit Intel processor only.
        /// </summary>
        IA64,

        /// <summary>
        /// A 64-bit AMD processor only.
        /// </summary>
        Amd64
    }
}