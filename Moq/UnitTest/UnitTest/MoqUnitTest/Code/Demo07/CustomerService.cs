﻿namespace MoqUnitTest.Code.Demo07
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerStatusFactory _customerStatusFactory;

        public CustomerService(ICustomerRepository customerRepository, ICustomerStatusFactory customerStatusFactory)
        {
            _customerRepository = customerRepository;
            _customerStatusFactory = customerStatusFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate)
         {
             var customer = new Customer(
                 customerToCreate.FirstName, customerToCreate.LastName);
             
             customer.StatusLevel = 
                 _customerStatusFactory.CreateFrom(customerToCreate);

             if (customer.StatusLevel == CustomerStatus.Platinum)
             {
                 _customerRepository.SaveSpecial(customer);
             }
             else
             {
                 _customerRepository.Save(customer);
             }
         }
    }
}