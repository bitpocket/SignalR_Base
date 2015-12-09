using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System.Threading;

namespace SignalRTest
{
	public class PlaneHub : Hub
	{
		public PlaneHub()
		{
			timer = new Timer(timercalback, null, 0, 1000);
		}

		private void timercalback(object state)
		{
			tick();
		}

		Timer timer;

		public static int ticker = 0;

		public void tick()
		{
			ticker++;

			Res res = new Res() { Ticker = ticker, GeneratedDate = DateTime.Now };
			Clients.All.ticker(res);
		}
	}

	public class Res
	{
		public int Ticker;
		public DateTime GeneratedDate;
	}
}