using AxiDAL.DTOs;
using AxiDAL.Factories;
using AxiLogic.Classes;
using AxiLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiLogic.Containers
{
    class ShipmentArticleContainer : IShipmentArticleContainer
    {
        private List<ShipmentArticle> _shipmentArticles;
        private DalFactory _dalFactory;

        public IReadOnlyCollection<ShipmentArticle> GetShipmentArticle()
        {
            return _shipmentArticles;
        }

        public ShipmentArticleContainer(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public void ClearShipmentArticles()
        {
            _shipmentArticles.Clear();
        }

        public List<ShipmentArticleDto> GetAllShipmentArticles()
        {
            var shipmentArticleDtos = _dalFactory.GetShipmentArticleDAL().GetAllShipmentArticlesFromShipment();
            List<ShipmentArticleDto> shipmentarticles = new();
            foreach (var shipmentArticleDto in shipmentArticleDtos)
            {
                shipmentarticles.Add(shipmentArticleDto);
            }

            return shipmentarticles;
        }

    }
}
