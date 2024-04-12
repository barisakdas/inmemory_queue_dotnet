﻿/****************************************************************************************************************************/
// GlobalNamespaces sınıfı dotnet'in sunduğu namespace'lerin artık sınıfların üzerinde yazılma zorunluluğunun ortadan       //
// kalkması ile kullandığımız bir yapıdır. Bu sınıf içerisine başında `global` etiketi ile eklediğimiz tüm namespace'ler    //
// artık aynı assembly içerisindeki diğer sınıflar içinde eklenmiş olacaktır. Dolayısıyla aynı namespace'i tekrar tekrar    //
// eklememize gerek yoktur. Burada eklenen her namespace için bir alan yaratıp onun altına ilgili namespace'leri eklemek    //
// bize aradığımızda daha kolay bir ulaşım sağlayacaktır.                                                                   //
//                                                                                                                          //
// ** NOT ** : EKLENEN TÜM LIBRARY LER AİT OLDUĞU ALANIN ALTINA VE ALFABETİK SIRALAMA BAZ ALINARAK EKLENMELİDİR.            //
/****************************************************************************************************************************/

/* (PROJECT) */

global using InMemoryQueue.Application.ServiceInterfaces;
global using InMemoryQueue.Background.ServiceInterfaces;
global using InMemoryQueue.Core.Dtos;
global using InMemoryQueue.Core.Entities;

/* (NUGET) */

global using ClosedXML.Excel;
global using Microsoft.Extensions.FileProviders;
global using Microsoft.Extensions.Hosting;
global using System.Data;
global using System.Threading.Channels;