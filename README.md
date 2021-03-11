[![Build Status](https://travis-ci.com/hopex-hk/hopex_CSharp.svg?branch=main)](https://travis-ci.com/hopex-hk/hopex_CSharp)

# Hopex C# SDK

This is Hopex C# SDK, This is a lightweight .NET library, you can use import to your C# project and use this SDK to query all market data and trading.

The SDK supports both synchronous and asynchronous RESTful API invoking.

## Table of Contents

- [Quick Start](#Quick-Start)

- [Usage](#Usage)

  - [Configuration](#Configuration)
  - [Folder structure](#Folder-Structure)
  - [Client](#Client)
  - [Response](#Response)
  
- [Request examples](#Request-examples)
  
  - [Account](#Account)
  - [Home](#Home)
  - [Market](#Market)
  - [Wallet](#Wallet)
  - [Trade](#Trade)


  

## Quick Start

*The SDK is compiled by .NET Standard 2.1*, you can import the source code in C# IDE. If you use Visual Studio, you can open the solution file directly.

The project **Hopex.SDK.Example** is a console application that you can start directly.

If you want to create your own application, you can follow below steps:

* Create a client (under namespace Hopex.SDK.Core.Client) instance.
* Call the method provided by client.

```csharp
// Get user account info
var accountClient = new AccountClient();

var accountData = accountClient.GetUserInfo().Result;

AppLogger.Info($"get user info, data:{JsonConvert.SerializeObject(accountData)}");
```

## Usage

### Configuration

If you need to access private data, you need to update **appsettings.json** into your solution. 

```json
{
  "ApiKey": "xxxxxxxxxxxx",
  "ApiSecret": "xxxxxxxxxxxx",
  "UserAgent": "xxxxxxxxxxxx" 
}
```

If you don't need to access private data, you can ignore this.

### Folder Structure

This is the folder and namespace structure of SDK source code and the description

- **Hopex.SDK.Core**: The core of the SDK
  - **Client**: The client classes that are responsible to access data
  - **Invoker**: Responsible to build the request with the signature
  - **Log**: The internal logger interface and implementations
  - **Model**: The internal data model used in core
- **Hopex.SDK.Model**: The data model that user need to care about
  - **Request**: The request data model
  - **Response**: The response data model
- **Hopex.SDK.Example**: The examples how to use **Core** and **Model** to access  API and read response.

As the example indicates, there are two important namespaces: **Hopex.SDK.Core.Client** and **Hopex.SDK.Model.Response**,  this section will introduce both of them below.

### Client

In this SDK, the client is the object to access the Hopex API. In order to isolate the private data with public data, and isolated different kind of data, the client category is designated to match the API category. 

All the client is listed in below table. Each client is very small and simple, it is only responsible to operate its related data, you can pick up multiple clients to create your own application based on your business.

| Data Category   | Client                               | Privacy | Access Type  |
| --------------- | ------------------------------------ | ------- | ------------ |
| Account         | AccountClient                        | Private | Rest         |
| Home            | HomeClient                           | Public  | Rest         |
| Market          | MarketClient                         | Public  | Rest         |
| Wallet          | WalletClient                         | Private | Rest         |
| Trade           | TradeClient                          | Private | Rest         |

#### Rest 

**Rest Client**: It invokes Rest API and get once-off response.

The method for all Rest Client is **asynchronism**, it invoke Hopex API asynchronous and returns a Task immediately without blocking further statements. If you would like to get the result **synchronous**, just simply access its *Result* property, it will be blocked until the data is returned.

```csharp
// You can call the method asynchronously
var task = client.GetIndexNotifyAsync();
// do something else
// ...
// wait for the task return
var result = await task;
  

// Or you can call the method synchronously
var result = client.GetIndexNotifyAsync().Result;
```

You can refer to C# programming guide [Asynchronous programming with async and await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) to know more details.


### Sign
In this SDK, the method param **isSign** is True,that means private REST request headers must include Authorization, Date and Digest.
```csharp
private static void BuildHead(HttpRequestMessage request, string method, string apiUrl, string payload, bool isSign)
{
    var headers = new Dictionary<string, string>
    {
      { "User-Agent", InvokerOption.UserAgent ?? string.Empty }   // Please Specified Your Exchange Name
    };

    if (isSign)
    {
      var date = DateTime.UtcNow.ToString("r");
      var digest = HashUtil.HmacSha256(payload);
      var textToSign = "";
      textToSign += $"date: {date}\n";
      textToSign += $"{method} {apiUrl} HTTP/1.1\n";
      textToSign += $"digest: SHA-256={digest}";
      var signature = HashUtil.HmacSha256(textToSign, InvokerOption.ApiSecret);
      var headAuth = $"hmac apikey=\"{InvokerOption.ApiKey}\", algorithm=\"hmac-sha256\", headers=\"date request-line digest\", signature=\"{signature}\"";
      
      headers.Add("Date", date);
      headers.Add("Digest", $"SHA-256={digest}");
      headers.Add("Authorization", headAuth);
    }

    foreach (var (key, value) in headers)
    {
      request.Headers.Add(key, value);
    }
}
```

### Response

In this SDK, the response is the object that define the data returned from API, which is deserialized from JSON string. It is the return type from each client method, you can declare the object use keyword *var* and don't need to specify the concrete type.

```csharp
// Use 'var' to declare a variable to hold the response
var statistResponse = client.GetIndexStatisticsAsync().Result;
```

After that you can check the value of the response and define your own business logic. The example in this SDK assume the JSON data from API is valid and do a basic validation. To make your application robust, you'd better consider all the possibilities of the data returned from API.

You can see it in **HttpRequest.cs**,api method invoker has rate limit,message means rate-limit exceed or hmac-sign  ret value is zero that means success,else fail

```csharp
// Check the status of response
if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    using (StreamReader sr = new StreamReader(await response.Content
        .ReadAsStreamAsync(cancellationToken).ConfigureAwait(false)))
    using (JsonReader reader = new JsonTextReader(sr))
    {
        var serializer = JsonSerializer.CreateDefault();
        var rps = serializer.Deserialize<ApiResponseModel<T>>(reader);

        if (!string.IsNullOrEmpty(rps.Message))
        {
            throw new InvokerFailException(rps.Message);
        }

        if (rps.Ret != 0)
        {
            throw new InvokerFailException(rps.ErrCode, rps.ErrStr);
        }

        return rps.Data;
    }
}
```

## Request Examples

### Home data

#### Index statistics

```csharp
var client = new HomeClient();
var statisticsResponse = client.GetIndexStatisticsAsync().Result;
```

#### Index notify

```csharp
var client = new HomeClient();
var notifyResponse = client.GetIndexNotifyAsync().Result;

```

### Market data

#### KLine

```csharp
var marketClient = new MarketClient();
var getKlineResponse = marketClient.GetKlineAsync("BTCUSDT", DateTimeUtil.GetTimestamps_seconds(DateTime.Now),
                DateTimeUtil.GetTimestamps_seconds(DateTime.Now.AddDays(-1)), CandlestickInterval.HOUR1).Result;
```

#### Depth

```csharp
var marketClient = new MarketClient();
var postQueryMarketDepthResponse = _marketClient.PostQueryMarketDepthAsync("BTCUSDT", 10).Result;
```

#### Latest trade

```csharp
var marketClient = new MarketClient();
var getTradesResponse = _marketClient.GetTradesAsync("BTCUSDT", 10).Result;
```

### Account

*Authentication is required.* 

```csharp
var accountClient = new AccountClient();
var getAIResult = accountClient.GetUserInfoAsync().Result;

public Task<GetUserInfoResponse> GetUserInfoAsync()
{
    return HttpRequest.Get<GetUserInfoResponse>("/api/v1/userinfo", null, true);
}
```

### Wallet

*Authentication is required.*

#### Deposit or Withdraw

```csharp
var getDepositWithdrawResponse = _walletClient.GetDepositWithdrawAsync(1, 10).Result;
```

#### Cancel withdraw

```csharp
var getUserWalletResponse = _walletClient.GetUserWalletAsync().Result;
```

### Trade

*Authentication is required.*

#### Create order

```csharp
var tradeClient = new TradeClient();
var orderId = _tradeClient.CreateOrderAsync(contractCode, (int)OrderTradeType.BuyLong, 10, 45000).Result;
```

#### Cancel order

```csharp
var tradeClient = new TradeClient();
long orderId = 1000000
var data = _tradeClient.CancelOrderAsync(contractCode, orderId).Result;
```

#### Create condition order

```csharp
var tradeClient = new TradeClient();
var data = _tradeClient.CreateConditionOrderAsync(contractCode, (int)OrderTradeType.BuyLong, OrderType.Limit.ToString(),
                60000, 10, 48000).Result;
```

#### Cancel condition order

```csharp
var tradeClient = new TradeClient();
long taskId = 1000000
var data = _tradeClient.CancelConditionOrderAsync(contractCode, taskId).Result;
```

#### Get open order

```csharp
var tradeClient = new TradeClient();
var getOpenOrdersResponse = _tradeClient.GetOpenOrdersAsync(contractCode).Result;

```

#### Historical orders

```csharp
var tradeClient = new TradeClient();
var req = new QueryHistoryOrdersRequest()
{
    ContractCodeList = new List<string>() { contractCode },
    TypeList = new List<int>(),
    Side = 0,
    StartTime = 0,
    EndTime = 0
};

var data = _tradeClient.QueryHistoryOrdersAsync(req).Result;
```







