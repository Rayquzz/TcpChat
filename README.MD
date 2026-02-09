\## Instrucțiuni de utilizare



\### Cerințe

\- Sistem de operare: Windows  

\- .NET SDK 8.0 sau mai nou  

\- Visual Studio 2022 sau .NET CLI (`dotnet`)



---



\### Configurare

Aplicația utilizează protocolul TCP și comunică printr-un port fix.



\- Port utilizat: `5000`

\- Adresa IP:

&nbsp; - `127.0.0.1` pentru rulare pe același calculator

&nbsp; - adresa IPv4 a calculatorului server pentru rulare în rețea (LAN)



Adresa IP și portul trebuie să fie identice în aplicația server și client.



---



\### Pornirea serverului

1\. Deschide proiectul server în Visual Studio

2\. Setează proiectul server ca \*\*Startup Project\*\*

3\. Rulează aplicația



Serverul va afișa un mesaj de confirmare că rulează și ascultă conexiuni.



---



\### Pornirea clientului

1\. Deschide proiectul client

2\. Rulează aplicația client

3\. După conectare, în consolă va apărea un mesaj de confirmare



---



\### Rularea mai multor clienți

Pentru a conecta mai mulți clienți simultan:

\- rulează clientul de mai multe ori folosind opțiunea \*\*Start New Instance\*\*

\- sau pornește aplicația client din mai multe terminale



Fiecare instanță reprezintă un client diferit.



---



\### Utilizarea aplicației

\- Introdu mesajul dorit în consola clientului și apasă Enter

\- Mesajul va fi trimis către server

\- Serverul va retransmite mesajul către toți clienții conectați

\- Mesajele primite vor fi afișate automat în consolă



---



\### Oprirea aplicației

\- Închide consola clientului pentru deconectare

\- Oprește serverul după ce toți clienții s-au deconectat



Conexiunile sunt închise corect conform regulilor TCP.



