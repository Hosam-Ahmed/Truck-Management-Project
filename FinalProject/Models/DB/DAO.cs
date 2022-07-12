using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models.DB;

namespace FinalProject.Models
{
    internal class DAO
    {

        public static List<IndividualTruck> GetIndividualTrucks()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.IndividualTrucks.Where(t => t.Status == "Available for rent").ToList();
            }
        }



        public static void addNewTruck(IndividualTruck it)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.IndividualTrucks.Add(it);
                ctx.SaveChanges();
            }
        }



        public static void addTruckNewModel(TruckModel tm)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.TruckModels.Add(tm);
                ctx.SaveChanges();
            }
        }

        public static void addTruckExistingModel(TruckModel tm)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.TruckModels.Add(tm);
                ctx.Entry(tm.IndividualTrucks).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                ctx.SaveChanges();
            }
        }

        public static List<TruckDetailsDisplay> GetTruckDetails(string model)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {

                return ctx.IndividualTrucks.Include(it => it.TruckModel).Where(tm => tm.TruckModel.Model == model).Select(
                    td => new TruckDetailsDisplay()
                    {
                        TruckId = td.TruckId,
                        Model = td.TruckModel.Model,
                        Colour = td.Colour,
                        DailyRentalPrice = td.DailyRentalPrice,
                        Size = td.TruckModel.Size,
                        Status = td.Status,
                    }).ToList();
            }
        }

        public static IndividualTruck GetTruckByID(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.IndividualTrucks.Where(it => it.TruckId == id).FirstOrDefault();
            }

        }

        public static IndividualTruck getTruckByRegistartionNumber(string rego)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.IndividualTrucks.Where(it => it.RegistrationNumber.Equals(rego)).FirstOrDefault();
            }

        }

        public static List<TruckFeature> getExistingTruckFeature()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckFeatures.ToList();
            }
        }

        public static List<TruckDetailsDisplay> GetTruckDetails()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {

                return ctx.IndividualTrucks.Include(it => it.TruckModel).Select(
                    td => new TruckDetailsDisplay()
                    {
                        TruckId = td.TruckId,
                        Model = td.TruckModel.Model,
                        Colour = td.Colour,
                        DailyRentalPrice = td.DailyRentalPrice,
                        Size = td.TruckModel.Size,
                        Status = td.Status,


                    }).ToList();
            }
        }


        public static List<TruckEditDetails> truckEditDetails(string model)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {

                return ctx.IndividualTrucks.Include(it => it.TruckModel).Where(tm => tm.TruckModel.Model == model).Select(
                    td => new TruckEditDetails()
                    {
                        TruckId = td.TruckId,
                        Colour = td.Colour,
                        RegistrationNumber = td.RegistrationNumber,
                        RegistrationExpiryDate = td.RegistrationExpiryDate,
                        WofexpiryDate = td.WofexpiryDate,
                        DailyRentalPrice = td.DailyRentalPrice,
                        AdvanceDepositRequired = td.AdvanceDepositRequired,
                        Seats = td.TruckModel.Seats,
                        Model = td.TruckModel.Model,
                        Status = td.Status,
                    }).ToList();
            }
        }

        public static List<TruckFeatureAssociation> getTruckFeatures(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckFeatureAssociations.Include(f1 => f1.Feature).Where(truck => truck.TruckId == id).ToList();
            }
        }


        public static void addTruckFeatures(TruckFeatureAssociation tfa)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.TruckFeatureAssociations.Add(tfa);
                ctx.SaveChanges();
            }
        }

        public static List<TruckEditDetails> GetTrucks()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {

                return ctx.IndividualTrucks.Include(it => it.TruckModel).Select(
                    td => new TruckEditDetails()
                    {
                        TruckId = td.TruckId,
                        Colour = td.Colour,
                        RegistrationNumber = td.RegistrationNumber,
                        RegistrationExpiryDate = td.RegistrationExpiryDate,
                        WofexpiryDate = td.WofexpiryDate,
                        DailyRentalPrice = td.DailyRentalPrice,
                        AdvanceDepositRequired = td.AdvanceDepositRequired,
                        Seats = td.TruckModel.Seats,
                        Model = td.TruckModel.Model,
                        Status = td.Status,
                    }).ToList();
            }
        }


        public static TruckModel searchTruckByModel(string model)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckModels.Where(tm => tm.Model == model).FirstOrDefault();
            }
        }

        public static IndividualTruck getTruckWithModel(string model)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.IndividualTrucks.Where(tm => tm.TruckModel.Model == model).FirstOrDefault();
            }
        }

        public static void customTruckTable(IndividualTruck updateTruck, TruckModel updateModel)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {

                ctx.Entry(updateTruck).State = EntityState.Modified;
                ctx.Entry(updateModel).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }


        public static void deleteExistingFeature(TruckFeatureAssociation tfa)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.TruckFeatureAssociations.Remove(tfa);
                ctx.SaveChanges();
            }

        }



        //Add Customer
        public static void addCustomer(TruckCustomer cust)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.TruckCustomers.Add(cust);
                ctx.SaveChanges();
            }
        }

        //Search Customer By licensenumber
        public static TruckCustomer searchCustomer(string licenseNumber)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckCustomers.Where(cust => cust.LicenseNumber == licenseNumber).FirstOrDefault();
            }
        }

        public static List<TruckCustomer> getCustomer()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckCustomers.ToList();
            }
        }

        public static TruckPerson getCustomerOnly(int customerID)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckPeople.Include(tc => tc.TruckCustomer).Where(tp => tp.PersonId == customerID).FirstOrDefault();
            }
        }

        //Getting all trucks that are rented
        public static List<IndividualTruck> getRentedTrucks()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.IndividualTrucks.Where(t => t.Status == "Rented").ToList();
            }
        }

        //Searching Truck by Model
        public static TruckModel searchTruckByModelID(IndividualTruck truck)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckModels.Where(tm => tm.ModelId == truck.TruckModelId).FirstOrDefault();
            }
        }

        //Searching Truck for Model
        public static TruckModel searchTruckModelWithTruckID(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckModels.Include(it => it.IndividualTrucks).Where(tm => tm.ModelId == id).FirstOrDefault();
            }
        }

        //Renting Truck
        public static void rentTruck(TruckRental rentTruck, IndividualTruck truck)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                truck.Status = "Rented";

                ctx.TruckRentals.Add(rentTruck);
                ctx.Entry(truck).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        //Return Truck
        public static void returnTruck(TruckRental returnTruck, IndividualTruck truck)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                //updating tables on each database
                ctx.Entry(returnTruck).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(truck).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        //Search Truck by ID
        public static IndividualTruck searchTruckRego(string rego)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.IndividualTrucks.Where(tm => tm.RegistrationNumber == rego).FirstOrDefault();
            }
        }

        //Search Customer By ID
        public static TruckCustomer searchCustomerID(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckCustomers.Where(cust => cust.CustomerId == id).FirstOrDefault();
            }
        }

        //Search rented by
        public static TruckRental searchRented(IndividualTruck id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckRentals.Where(tr => tr.TruckId == id.TruckId).FirstOrDefault();
            }
        }

        //Search customer by id
        public static List<TruckRental> viewRentedCustomer(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckRentals.Where(tr => tr.CustomerId == id).ToList();
            }
        }

        //Search for trucks with 2 dates
        public static List<TruckRental> searchRentedByDate(DateTime fromDate, DateTime toDate)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckRentals.Where(tr => tr.RentDate >= fromDate).Where(tr => tr.ReturnDueDate <= toDate).ToList();
            }
        }

        //getting rented
        public static List<TruckRental> viewRented()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckRentals.ToList();
            }
        }



        public static string username;

        public static void updateEmployeeRecord(TruckPerson p)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(p.TruckEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                ctx.SaveChanges();
            }
        }

        public static void updateCustomerRecord(TruckPerson p)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(p.TruckCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                ctx.SaveChanges();
            }
        }
        public static void updatePesonal(List<EmployeeDetails> data)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                foreach (EmployeeDetails bc in data)
                {
                    TruckPerson p = ctx.TruckPeople.Include(bt => bt.TruckEmployee).Where(b => b.TruckEmployee.Username == username).FirstOrDefault();
                    p.Address = bc.Address;
                    p.Telephone = bc.Telephone;
                    p.Name = bc.Name;
                    p.TruckEmployee.OfficeAddress = bc.OfficeAddress;
                    p.TruckEmployee.PhoneExtensionNumber = bc.PhoneExtensionNumber;
                    p.TruckEmployee.Password = bc.Password;
                    ctx.Entry(p).State = EntityState.Modified;
                    ctx.Entry(p.TruckEmployee).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public static List<EmployeeDetails> fetchPersonalInfo()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {

                return ctx.TruckPeople.Include(bt => bt.TruckEmployee).Where(em => em.TruckEmployee.Username == username).Select(
                    bc => new EmployeeDetails()
                    {
                        PersonId = bc.PersonId,
                        EmployeeId = bc.TruckEmployee.EmployeeId,
                        Name = bc.Name,
                        Address = bc.Address,
                        Telephone = bc.Telephone,
                        OfficeAddress = bc.TruckEmployee.OfficeAddress,
                        PhoneExtensionNumber = bc.TruckEmployee.PhoneExtensionNumber,
                        Username = bc.TruckEmployee.Username,
                        Password = bc.TruckEmployee.Password,
                        Role = bc.TruckEmployee.Role,
                    }).ToList();
            }
        }

        public static List<CustomerDetails> fetchCustomerInfo()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckCustomers.Include(c => c.Customer).Select(p => new CustomerDetails()
                {
                    PersonId = p.Customer.PersonId,
                    CustomerId = p.CustomerId,
                    Name = p.Customer.Name,
                    Telephone = p.Customer.Telephone,
                    Address = p.Customer.Address,
                    Age = p.Age,
                    LicenseExpiryDate = p.LicenseExpiryDate,
                    LicenseNumber = p.LicenseNumber,
                }).ToList();
            }
        }

        public static void login(TruckEmployee truckEmployee)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                if (validUser(truckEmployee.Username, truckEmployee.Password))
                {
                    username = truckEmployee.Username;
                }
                else
                {
                    throw new Exception("Please enter correct username and password");
                }
            }
        }

        public static bool validUser(string username, string password)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                TruckEmployee employee = ctx.TruckEmployees.Where(em => em.Username == username).Where(ps => ps.Password == password).FirstOrDefault();
                if (employee == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public static TruckPerson searchEmployeeByID(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckPeople.Include(p => p.TruckEmployee).Where(em => em.TruckEmployee.EmployeeId == id).FirstOrDefault();
            }
        }
        public static TruckPerson searchCustomerByID(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckPeople.Include(p => p.TruckCustomer).Where(em => em.TruckCustomer.CustomerId == id).FirstOrDefault();
            }
        }
        public static List<PersonInformation> getPeople()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckPeople.Select(p => new PersonInformation()
                {
                    PersonId = p.PersonId,
                    Address = p.Address,
                    Name = p.Name,
                    Telephone = p.Telephone,
                }).ToList();
            }
        }
        public static List<EmployeeDetails> GetEmployee()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckEmployees.Include(em => em.Employee).Select(p => new EmployeeDetails()
                {
                    EmployeeId = p.EmployeeId,
                    PersonId = p.Employee.PersonId,
                    Name = p.Employee.Name,
                    Telephone = p.Employee.Telephone,
                    Address = p.Employee.Address,
                    Username = p.Username,
                    Password = p.Password,
                    OfficeAddress = p.OfficeAddress,
                    Role = p.Role,
                    PhoneExtensionNumber = p.PhoneExtensionNumber,

                }).ToList();
            }
        }
        public static List<CustomerDetails> GetCustomer()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckCustomers.Include(c => c.Customer).Select(p => new CustomerDetails()
                {
                    CustomerId = p.CustomerId,
                    PersonId = p.Customer.PersonId,
                    Name = p.Customer.Name,
                    Telephone = p.Customer.Telephone,
                    Address = p.Customer.Address,
                    Age = p.Age,
                    LicenseExpiryDate = p.LicenseExpiryDate,
                    LicenseNumber = p.LicenseNumber,
                }).ToList();
            }
        }

        public static List<TruckPerson> GetPersonID()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckPeople.ToList();
            }
        }

        public static List<TruckEmployee> GetEmployeeID()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckEmployees.ToList();
            }
        }
        public static List<TruckCustomer> GetCustomerID()
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckCustomers.ToList();
            }
        }
        private static bool containsUserName(string username)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                TruckEmployee truckEmployee = ctx.TruckEmployees.Where(em => em.Username == username).FirstOrDefault();
                if (truckEmployee == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static void addEmployee(TruckEmployee truckEmployee)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                if (!containsUserName(truckEmployee.Username))
                {
                    ctx.TruckEmployees.Add(truckEmployee);
                    ctx.SaveChanges();
                }

                else
                {
                    throw new Exception("Please choose another username");
                }
            }
        }

        public static List<PersonInformation> getPeople(int id)
        {
            using (DAD_HosamContext ctx = new DAD_HosamContext())
            {
                return ctx.TruckPeople.Where(bt => bt.PersonId == id).Select(p => new PersonInformation()
                {
                    PersonId = p.PersonId,
                    Address = p.Address,
                    Name = p.Name,
                    Telephone = p.Telephone,
                }).ToList();
            }
        }


        public static int validEmptyInput(Grid data)
        {
            int count = 0;
            foreach (Control ctl in data.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)ctl;

                    if (tb.Text.Length == 0)
                    {

                        tb.BorderBrush = Brushes.Red;
                        count = 1;
                    }
                    else
                    {
                        tb.BorderBrush = Brushes.Black;
                    }
                }

                else if (ctl.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)ctl;

                    if (cb.SelectedIndex == -1)
                    {
                        cb.BorderBrush = Brushes.Red;
                        count = 1;
                    }
                    else
                        cb.BorderBrush = Brushes.Black;
                }

                else if (ctl.GetType() == typeof(DatePicker))
                {
                    DatePicker dp = (DatePicker)ctl;

                    if (dp.SelectedDate == null)
                    {
                        dp.BorderBrush = Brushes.Red;
                        count = 1;
                    }
                    else
                        dp.BorderBrush = Brushes.Black;
                }
            }
            return count;

        }
    }
}
