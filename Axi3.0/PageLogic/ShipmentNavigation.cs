using AxiLogic.Helpers;

namespace Axi3._0.PageLogic
{
    public class ShipmentNavigation
    {
        public void OnLoad()
        {
           ContainerFactory.ShipmentContainer.LoadProcessableShipments();
        }
    }
}