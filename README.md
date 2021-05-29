# TrasactionMicroservices

This is a microservice application for transactions made by a client.
To run the application first, run migration and restore dependences. NOTE: Application is built on .net5.0 framework.
 The application has swagger intergated so you can access it using http://localhost:5001/swagger/index.html 

There are two endpoints the Update Transaction and Get transaction, the update is a post request, the body of the request is as follows
      
      {
        "clientId":"string",
        
        "walletAddress":"string",
        
        "recieverWalletAddress": "string",
        
        "currencyType":"string"
      }
 
The Get transaction takes an Id of type guid which is the Id off the updated transaction and retrieves the transaction details.  
