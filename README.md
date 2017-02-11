# twmvc26sample-netcore-caching
淺談 ASP.NET Caching 技術與實踐範例程式碼

## ASP.NET Core Caching

### NuGet 安裝

	Install-Package Microsoft.Extensions.Caching.Memory

### Startup 設定

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
      services.AddSingleton<IService<Employee>, EmployeeService>();

      services.AddMemoryCache();
    }

### 注入服務	

    private readonly IMemoryCache _memoryCache;
    private readonly IService<Employee> _service;

    //// 1.注入 IMemoryCache 服務
    public EmployeeController(IMemoryCache memCache, IService<Employee> service)
    {
      _memoryCache = memCache;
      _service = service;
    }

### 使用方式

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


----------

以上。

若有不清楚或是需要進一步協助請再讓我知道。謝謝。
