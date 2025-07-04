// using System.Collections.Generic;
// using Firebase.Analytics;
// using GameAnalyticsSDK;

using System.Collections.Generic;
using Io.AppMetrica;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.App
{
    public sealed class ReleaseAnalyticsLogger : IAnalyticsLogger
    {
        public void LogEvent(string eventName, params AnalyticsParameter[] parameters)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                eventName = AnalyticsConst.UNDEFINED;
            }
            
            if (parameters is not {Length: > 0})
            {
                this.LogEventOnly(eventName);
            }
            else
            {
                this.LogEventWithParams(eventName, parameters);
            }
        }

        private void LogEventOnly(string eventName)
        {
            AppMetrica.ReportEvent(eventName);
            // FirebaseAnalytics.LogEvent(eventName);
            // GameAnalytics.NewDesignEvent(eventName);
            //TODO: Other trackers...
        }

        private void LogEventWithParams(string eventName, AnalyticsParameter[] parameters)
        {
            var count = parameters.Length;
           
            var appMetricaParams = new Dictionary<string, object>(count);
            // var gaParams = new Dictionary<string, object>(count);
            // var firebaseParams = new Firebase.Analytics.Parameter[count];
            
            for (var i = 0; i < count; i++)
            {
                var parameter = parameters[i];
                var id = parameter.name;
                var value = parameter.value;
                
                appMetricaParams.Add(id, value);
                // gaParams.Add(id, value);
                // firebaseParams[i] = new Firebase.Analytics.Parameter(id, value);
            }
            
            AppMetrica.ReportEvent(eventName, JsonConvert.SerializeObject(appMetricaParams));
            // FirebaseAnalytics.LogEvent(eventName, firebaseParams);
            // GameAnalytics.NewDesignEvent(eventName, gaParams);
            //TODO: Other trackers...
        }
    }
}