namespace Badass_Pirates.Interfaces
{
    #region

    using Badass_Pirates.GameObjects.Ships;

    #endregion

    internal interface ISink
    {
        void Sink(Objects.VirtualPlayer player);
    }
}