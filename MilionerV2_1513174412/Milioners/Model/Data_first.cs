using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Milioners
{
    class Data_first
    {
        public static void Save_d(string q, string a1, string a2, string a3, string a4)
        {

            using (var db = new MilionEntities())
            {


                var questions = new Questio { Questio1 = q, Answer_1 = a1, Answer_2 = a2, Answer_3 = a3, Answer_4 = a4 };
                db.Questios.Add(questions);
                db.SaveChanges();

            }

        }

        public static void Update_Questio_d(string Questio_old, string Questio, string Answer_1, string Answer_2, string Answer_3, string Answer_4)
        {
            try
            {
                using (var db = new MilionEntities())
                {

                    var query = (from b in db.Questios
                                 where b.Questio1 == Questio_old
                                 select b).Single();
                    if (query == null)
                        return;


                    query.Questio1 = Questio;
                    query.Answer_1 = Answer_1;
                    query.Answer_2 = Answer_2;
                    query.Answer_3 = Answer_3;
                    query.Answer_4 = Answer_4;
                    db.SaveChanges();


                }
            }
            catch (Exception ex)
            {

            }
       }

        public static void Delete_Questio_d(string Questio)
        {
            try
            {
                using (var db = new MilionEntities())
                {
                   
                    var query = from b in db.Questios
                                where b.Questio1 == Questio
                                select b;
                    db.Questios.RemoveRange(query);
                    db.SaveChanges();
                  
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
