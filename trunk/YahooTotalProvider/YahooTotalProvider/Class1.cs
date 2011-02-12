using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantFactory;
using NLog;
using QuantFactory.Execution;
using QuantFactory.Providers;
using SmartQuant;
using SmartQuant.Data;
using SmartQuant.FIX;
using System.Globalization;
using System.Configuration;
using SmartQuant.Providers;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;


namespace TotalProvider
{
    public abstract class TotalProvider : IProvider , IMarketDataProvider, IInstrumentServer,IHistoryProvider,IHistoricalDataProvider, IInstrumentPricer
    {



        #region IProvider Members

        public abstract void Connect(int timeout);

        public abstract void Connect();

        public event EventHandler Connected;

        public abstract void Disconnect();

        public event EventHandler Disconnected;

        public event ProviderErrorEventHandler Error;

        public extern byte Id {get;}

        public extern bool IsConnected {get;}
        public extern string Name { get; }

        public abstract void Shutdown();

        public extern ProviderStatus Status {get;}

        public event EventHandler StatusChanged;

        public abstract string Title { get; }
        public abstract string URL { get; }

        

        #endregion
        
        #region IInstrumentServer Members

        /// <summary>
        /// Closes this instance.
        /// </summary>
       extern void IInstrumentServer.Close();

       extern InstrumentList IInstrumentServer.Load();

       extern void IInstrumentServer.Open(string dataBase);

       extern void IInstrumentServer.Remove(Instrument instrument);
       extern void IInstrumentServer.Save(Instrument instrument);
         

        #endregion
        
       #region IHistoryProvider Members

       extern bool IHistoryProvider.BarSupported {get;}
       extern bool IHistoryProvider.DailySupported  {get;}

       extern Bar[] IHistoryProvider.GetBarHistory(IFIXInstrument instrument, DateTime datetime1, DateTime datetime2, int barSize);


       extern  Daily[] IHistoryProvider.GetDailyHistory(IFIXInstrument instrument, DateTime datetime1, DateTime datetime2, bool dividendAndSplitAdjusted);

       extern  MarketDepth[] IHistoryProvider.GetMarketDepthHistory(IFIXInstrument instrument, DateTime datetime1, DateTime datetime2);
      
       extern Quote[] IHistoryProvider.GetQuoteHistory(IFIXInstrument instrument, DateTime datetime1, DateTime datetime2);
      

       extern Trade[] IHistoryProvider.GetTradeHistory(IFIXInstrument instrument, DateTime datetime1, DateTime datetime2);
       

       extern bool IHistoryProvider.MarketDepthSupported {get;}

       extern bool IHistoryProvider.QuoteSupported{get;}

       extern bool IHistoryProvider.TradeSupported {get;}
       

       #endregion

       #region IProvider Members

       void IProvider.Connect(int timeout)
       {
           throw new NotImplementedException();
       }

       void IProvider.Connect()
       {
           throw new NotImplementedException();
       }

       event EventHandler IProvider.Connected
       {
           add { throw new NotImplementedException(); }
           remove { throw new NotImplementedException(); }
       }

       void IProvider.Disconnect()
       {
           throw new NotImplementedException();
       }

       event EventHandler IProvider.Disconnected
       {
           add { throw new NotImplementedException(); }
           remove { throw new NotImplementedException(); }
       }

       event ProviderErrorEventHandler IProvider.Error
       {
           add { throw new NotImplementedException(); }
           remove { throw new NotImplementedException(); }
       }

       byte IProvider.Id
       {
           get { throw new NotImplementedException(); }
       }

       bool IProvider.IsConnected
       {
           get { throw new NotImplementedException(); }
       }

       string IProvider.Name
       {
           get { throw new NotImplementedException(); }
       }

       void IProvider.Shutdown()
       {
           throw new NotImplementedException();
       }

       ProviderStatus IProvider.Status
       {
           get { throw new NotImplementedException(); }
       }

       event EventHandler IProvider.StatusChanged
       {
           add { throw new NotImplementedException(); }
           remove { throw new NotImplementedException(); }
       }

       string IProvider.Title
       {
           get { throw new NotImplementedException(); }
       }

       string IProvider.URL
       {
           get { throw new NotImplementedException(); }
       }

       #endregion
                
        #region IHistoricalDataProvider Members

       abstract public int[] BarSizes {get;}

       extern public void CancelHistoricalDataRequest(string requestId);

       extern public HistoricalDataRange DataRange {get;}

       extern public HistoricalDataType DataType {get; }

       public event HistoricalDataEventHandler HistoricalDataRequestCancelled;

       public event HistoricalDataEventHandler HistoricalDataRequestCompleted;

       public event HistoricalDataErrorEventHandler HistoricalDataRequestError;

       abstract public int MaxConcurrentRequests { get; }

       public event HistoricalBarEventHandler NewHistoricalBar;

       public event HistoricalMarketDepthEventHandler NewHistoricalMarketDepth;

       public event HistoricalQuoteEventHandler NewHistoricalQuote;

       public event HistoricalTradeEventHandler NewHistoricalTrade;

       abstract public void SendHistoricalDataRequest(HistoricalDataRequest request);

       #endregion

       #region IMarketDataProvider Members

       abstract public IBarFactory BarFactory {get;set;}


       abstract public void CancelL1Subscription(Instrument instrument);

       abstract public void CancelL2Subscription(Instrument instrument);
       

       public event SubscriptionAbortEventHandler L1SubscriptionAborted;

       public event SubscriptionEventHandler L1SubscriptionFailed;

       public event SubscriptionEventHandler L1SubscriptionStopped;

       public event SubscriptionEventHandler L1SubscriptionSucceeded;

       public event SubscriptionAbortEventHandler L2SubscriptionAborted;

       public event SubscriptionEventHandler L2SubscriptionFailed;

       public event SubscriptionEventHandler L2SubscriptionStopped;

       public event SubscriptionEventHandler L2SubscriptionSucceeded;

       public event MarketDataSnapshotEventHandler MarketDataSnapshot;

       public event BarEventHandler NewBar;

       public event BarEventHandler NewBarOpen;

       public event BarSliceEventHandler NewBarSlice;

       public event CorporateActionEventHandler NewCorporateAction;

       public event DailyEventHandler NewDailyClose;

       public event DailyEventHandler NewDailyHigh;

       public event DailyEventHandler NewDailyLow;

       public event DailyEventHandler NewDailyOpen;

       public event DailyEventHandler NewDailyTotalVolume;

       public event DataEventHandler NewData;

       public event FundamentalEventHandler NewFundamental;

       public event MarketDataEventHandler NewMarketData;

       public event MarketDepthEventHandler NewMarketDepth;

       public event QuoteEventHandler NewQuote;

       public event TradeEventHandler NewTrade;

       abstract public void SubscribeL1(InstrumentList instruments);
       virtual public void SubscribeL1(Instrument instrument)
       {
           throw new NotImplementedException();
       }

       virtual public void SubscribeL2(Instrument instrument)
       {
           throw new NotImplementedException();
       }

       #endregion

       #region IInstrumentPricer Members

       virtual public double Delta(DateTime dateTime)
       {
           throw new NotImplementedException();
       }

       virtual public double Delta()
       {
           throw new NotImplementedException();
       }

       virtual public double Gamma(DateTime dateTime)
       {
           throw new NotImplementedException();
       }

       virtual public double Gamma()
       {
           throw new NotImplementedException();
       }

       virtual public bool IsLastPriceFromCache
       {
           get { throw new NotImplementedException(); }
       }

       virtual public double LastPrice
       {
           get { throw new NotImplementedException(); }
       }

       virtual public DateTime LastPriceDate
       {
           get { throw new NotImplementedException(); }
       }

       virtual public double Price(DateTime dateTime)
       {
           throw new NotImplementedException();
       }

       virtual public double Price(double marketQuotation)
       {
           throw new NotImplementedException();
       }

       virtual public double Price()
       {
           throw new NotImplementedException();
       }

       virtual public double Rho(DateTime dateTime)
       {
           throw new NotImplementedException();
       }

       virtual public double Rho()
       {
           throw new NotImplementedException();
       }

       virtual public bool SavePriceToDatabase()
       {
           throw new NotImplementedException();
       }

       virtual public double Theta(DateTime dateTime)
       {
           throw new NotImplementedException();
       }

       virtual public double Theta()
       {
           throw new NotImplementedException();
       }

       virtual public double Vega(DateTime dateTime)
       {
           throw new NotImplementedException();
       }

       virtual public double Vega()
       {
           throw new NotImplementedException();
       }

       virtual public double Volatility(DateTime dateTime1, DateTime dateTime2)
       {
           throw new NotImplementedException();
       }

       virtual public double Volatility()
       {
           throw new NotImplementedException();
       }

       #endregion


    }
     
}
