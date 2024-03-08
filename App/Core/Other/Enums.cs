namespace Core.Other
{
    public enum PrivilageStateEnum : int
    {
        Deny=0,
        Allow = 1,
    
    }

    public enum RiskRateEnum : int
    {
        Low = 0,
        Medium = 1,
        High = 2,

    }

    public enum ActiveEnum : int
    {
        NoneActive = 0,
        Active = 1

    }



    //public enum AttachmentTypeEnum : int
    //{
    //    Product = 1,
    //    ResurantProfile,
    //    DeliveryProfile,
    //    CustomerProfile,
    //    Offer,
    //    Story,
    //}

    //public enum UserTypeEnum : int
    //{
    //    System = 1,
    //    Resturant,
    //    Delivery,
    //    Client


    //}

    //public enum AppNotifyTopicEnum : int
    //{
    //    All = 1,
    //    Resturant ,
    //    Delivery ,
    //    Client,
    //    NotDefined 
    //}

    //public enum AppNotifyInfo1Enum : int
    //{
    //    NewOrderToDelivery = 1
    //    ,NewOrderToResturant = 2
    //    ,Chat_Cust_Delivery = 3
    //    ,Chat_Cust_Resturant = 4
    //    ,Chat_Delivery_Resturant = 5

    //}


    //public enum DeliveryTypeEnum : int
    //{
    //    Company = 0,Person

    //}

    //public enum PaymentTypeEnum : int
    //{
    //     Cash = 0, Epayment =1,Wallet =2

    //}

    ////,ust be the same UserTypeEnum
    //public enum ProfileTypeEnum : int
    //{
    //    Resturant = 2, Delivery, Client

    //}   

    //public enum FreeMealStatusEnum : int
    //{
    //    Cancelled =-1,  Available = 0, Consumed =1

    //}

    //public enum FreeMealTypeEnum : int
    //{
    //     FreeMeal = 0, FastingBreakfast = 1

    //}

    //public enum RequestMoneyStatus : int
    //{
    //    Pending = 0, Completed=1,Rejected=-1

    //}

    //public enum RequestTransfereStatus : int
    //{
    //    New = 0, archived = 1

    //}

    //public enum WalletTransTypeEnum : int
    //{
    //    Out = 0, In

    //}

    //public enum OrderStatusEnum : int
    //{
    //  Cancelled=-1,  Pending = 0, Confirmed=1, recieved=2,OutForDelivery=3 
    //}    


    //public enum SpecialOrderStatusEnum : int
    //{

    //    //Cancelled = -1, New = 0, Recieved = 2, Delivered = 3
    //    Cancelled = -1, Pending = 0, Confirmed = 1, Recieved = 2, Delivered = 3
    //}

    //public enum DeliveryStatusEnum : int
    //{
    //   Pending = 0, accepted = 1, OnTheWay = 2, Received = 3, Deliverd = 4

    //}


    //public enum ChatTypeEnum : int
    //{
    //    Cust_Delivery = 0, Cust_System = 1, System_Resturant = 2, System_Delivery = 3

    //}


    //public enum EpaymentLogType : int
    //{
    //    BeginCreateLink = 1,
    //    ResultCreateLink,
    //    BeginCheckPayment,
    //    ResultCheckPayment,
    //    BeginChargeCreateLink,
    //    ResultChargeCreateLink,
    //    BeginChargeCheckPayment,
    //    ResultChargeCheckPayment,
    //    BeginCreateLinkSpecialOrder,
    //    ResultCreateLinkSpecialOrder,
    //    BeginCheckPaymentSpecialOrder,
    //    ResultCheckPaymentSpecialOrder
    //}


    //public enum MessageType : int
    //{
    //    Send=0,Recieve
    //}

}
