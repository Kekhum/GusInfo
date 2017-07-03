# GusInfo
.NET library for receiving info about Polish company registered in GUS. This package are using Api service from [GUS site](https://wyszukiwarkaregon.stat.gov.pl/appBIR/index.aspx)
To access the service you need to receive USER_KEY from GUS. More info you can find [here](http://bip.stat.gov.pl/dzialalnosc-statystyki-publicznej/rejestr-regon/interfejsyapi/jak-skorzystac-informacja-dla-podmiotow-komercyjnych/).

```
var info = new new GusClient(USER_KEY).GetCompanyByNip("PL5261040828");
Console.Writeln($"Name:{info.Name}, Nip:{info.Nip}, Regon:{info.Regon}, Address:{info.ZipCode} {info.City} {info.Street}");
```
