This project will calculate the loss of reinsurance as per the given requirement

DB/ReInsuranceDB.cs - DB consists Event and Deal data
Helper/ReInsuranceEnums.cs - Enum of Region, Peril and EventArrayPostion which was used in the project


BusinessLogic/ReInsuranceBuilder.cs - Build the businesslogic of GetEvents, GetDeal and Calculate the loss
BusinessLogic/ReInsuranceCreator.cs - Parse all events and invoke the ReinsuranceBuilder business logic - This will separates the business logic implementation
BusinessLogic/ReInsuranceTemplate.cs - Read the Events and Deals from DB and not exposed to outside world

Interface/IManageReInsurance.cs - All interfaces are placed here

Model/DealModel.cs - Deal DB model class
