# sitecore-campaignlistexporter
![Trigerfish Logo](https://avatars.githubusercontent.com/u/78132139?v=4)

## What is it?
This is a Sitecore List Manager extension module that allows you to export the last known campaign name of a contact in a list.

## Why?
Our use-case was when a user unsubscribes from all EXM campaigns, we wanted to know the last one they received before unsubscribing.

## Compatibility
- (Tested on) Sitecore 10

## Prerequisites
- Working sc 10 instance
- xConnect service
- Custom Facets for sc Contacts

## Usage Note
Copy the Feature/code to your working sitecore repo Helix structure please refer to the File structure below on details.
You need a proper working Sitecore 10 instance along with xConnect in order to test this E2E which is beyond the scope of this repo.

### File Structure
``` bash

Feature/
└── code/
    └── ContactDataReaders
        ├── CampaignContactDataReader.cs  //class implementing IContactDataReader
    └── xConnectModels
        ├── ContactCustomFieldsFacet.cs   //custom Facet class for example
    └── App_config
        ├── Feature.ListManager.config    // Patch for OOTB App_Config/Sitecore/ListManagement/Sitecore.ListManagement.config
```

### sitecore-campaignlistexporter
- Sitecore ListManagement xConnect Web Export provides a way to export the Facet fields to the CSV.
- The code here extends this feature by adding a patch to App_Config/Sitecore/ListManagement/Sitecore.ListManagement.config  
to export the custom fields to the CSV.
- The patch file consists of a class implementing IContactDataReader which defines the functionality to export the last 
known campaign name from the contact interactions in a list & a field name which renders to column name on the exported CSV file.

### CSV example
![Screenshot](https://i.postimg.cc/52BHVQFZ/xls.png)

## Dependenent packages sc 10.0.0
- Sitecore.Kernel
- Sitecore.xConnect
- Sitecore.XConnect.Client
- Sitecore.XConnect.Client.Configuration
- Sitecore.EmailCampaign.Model
- Sitecore.ListManagement.XConnect
- Sitecore.ListManagement.XConnect.Web

## Good reference here on Listmanager fields export
![Link](https://sitecorify.com/list-manager-export-contacts-with-custom-facets/)

