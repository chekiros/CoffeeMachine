using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCoffeeMachine
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            try
            {


                using (var ctx = new ModelCoffeeMachine())
                {
                    DrinkKind stud = new WcfCoffeeMachine.DrinkKind() { kind = "BlackCoffee" };

                    ctx.kinds.Add(stud);
                    ctx.SaveChanges();
                }

                return string.Format("You entered: {0}", value);
             }

            catch(Exception ex)
            {
                return string.Format("Exception :  {0}", ex.Message);

            }
            
            
            }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
