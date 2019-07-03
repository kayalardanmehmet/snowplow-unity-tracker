using System;

namespace SnowplowTracker.Payloads.Contexts
{
    public class ApplicationContext: AbstractContext<ApplicationContext>
    {

        public ApplicationContext SetVersion(String version)
        {
            this.DoAdd(Constants.APP_VERSION, version);
            return this;
        }
        
        public ApplicationContext SetBuild(String build)
        {
            this.DoAdd(Constants.APP_BUILD, build);
            return this;
        }
        
        public override ApplicationContext Build()
        {
            Utils.CheckArgument (this.data.ContainsKey(Constants.APP_VERSION), "ApplicationContext requires 'version'.");
            Utils.CheckArgument (this.data.ContainsKey(Constants.APP_BUILD), "ApplicationContext requires 'build'.");
            this.schema = Constants.SCHEMA_APPLICATION;
            this.context = new SelfDescribingJson (this.schema, this.data);
            return this;
        }
    }
}