﻿using AutoMapper;
using NTier.Domain;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class OrdersController : Controller
    {
        IOrdersBusiness _order;

        public OrdersController(IOrdersBusiness orders)
        {
            this._order = orders;
        }
        // GET: Orders
        public ActionResult ListOrder()
        {
            var result = _order.GetAllUnConfirmedOrders()
            .Select(m => new OrderViewModel
            {
                Id = m.Id,
                Product = m.Product,
                User = m.User,
                OrderDate = m.OrderDate,
                ConfirmStatus = m.ConfirmStatus
            });

            return View(result);
        }

        public ActionResult ConfirmedListOrder()
        {
            var result = _order.GetAllConfirmedOrders()
            .Select(m => new OrderViewModel
            {
                Id = m.Id,
                Product = m.Product,
                User = m.User,
                OrderDate = m.OrderDate,
                ConfirmStatus = m.ConfirmStatus
            });

            return View(result);
        }

    }
}