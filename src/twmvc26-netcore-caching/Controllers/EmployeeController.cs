using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using twmvc26_netcore_caching.Models;
using twmvc26_netcore_caching.Servies;

namespace twmvc26_netcore_caching.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        private readonly IService<Employee> _service;

        //// 1.注入 IMemoryCache 服務
        public EmployeeController(IMemoryCache memCache, IService<Employee> service)
        {
            _memoryCache = memCache;
            _service = service;
        }

        public IActionResult Index()
        {
            var emps = SetGetMemoryCache();
            return View(emps);
        }

        private List<Employee> SetGetMemoryCache()
        {
            List<Employee> employees;

            //// 2.設定 Cache Key
            string key = "MyMemoryKey-Cache";

            //// 3.我們將嘗試從 Cache 取得資料
            //// 若嘗試取得失敗，則由服務層取得資料，否之從 MemoryCache 直接取出
            if (_memoryCache.TryGetValue(key, out employees) == false)
            {
                //// 4.從服務層取得資料
                employees = _service.GetAll().ToList();

                //// 5.設定快取項目「絕對過期時間」
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));

                //// 6.將取得資料設定進 Cache
                _memoryCache.Set(key, employees, cacheEntryOptions);

                ViewBag.Status = "資料加入到快取";
            }
            else
            {
                employees = _memoryCache.Get(key) as List<Employee>;
                ViewBag.Status = "從快取中取得資料";
            }

            return employees;
        }
    }
}