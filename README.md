# Kino-C-Sharp
Repozytorium zawiera projekt prostego systemu obsługi kupowania biletów na filmy w kinie.
Wojciech Kantor
Filip Regulski
Wiktor Kostera


Opis projektu
	Celem naszego projektu było wykonanie aplikacji służącej do obsługi systemu rezerwacji miejsc w kinie. W tym celu stworzyliśmy projekt Projekt, w którym zdefiniowaliśmy klasy, a następnie dołączyliśmy plik WPF o nazwie GuiProjekt, za pomocą którego zaprojektowaliśmy interaktywny interfejs graficzny pokazujący zasadnicze działanie aplikacji. Udało nam się osiągnąć założone cele w tym przede wszystkim implementacja bazy danych SQL za pomocą, której możemy przechowywać informację o dostępnych/zajętych miejscach w przypadku wyboru poszczególnego filmu. Ponadto zaimplementowaliśmy obsługę licznych wyjątków w przypadku np. błędnego wprowadzenia danych osoby kupującej. Oprócz tego korzystamy z obsługi własnego interfejsu i delegata, a także w ostatnim oknie programu obsługujemy zapis do pliku XML. Co więcej, pozostawiamy użytkownikowi możliwość zapisu zakupionego biletu do pliku w formie PDF oraz istnieje możliwość zeskanowania kodu QR, który również przechowuje informacje o zakupie. Zaimplementowaliśmy również własnoręcznie stworzone logo, które wyświetlane jest w interaktywnej formie GIF oraz liczne grafiki prezentujące aktualnie dostępne filmy. Z rzeczy, które mogłyby wzbogacić nasz projekt lecz których niestety nie zdążyliśmy już wprowadzić, możemy wskazać potencjalną obsługę bazy danych klientów, na podstawie, której korzystalibyśmy również z interfejsów takich jak IEquatable czy też IComparable.
 
Uruchomienie programu
Aby uruchomić program należy, pobrać plik FINALNY_PROJEKT.zip, następnie należy wyodrębnić folder. Po wejściu w wypakowany folder należy przejść do folderu GuiProjekt i wybrać plik projektu GuiProjekt.sln. Do tego wszystkiego należy mieć zainstalowaną bazę danych MySQL do którego należy wgrać bazę danych kino_sale oraz rozszerzenia iText7, iTextSharp, QRCoder, aby móc w pełni korzystać z możliwości programu. Następnie po kliknięciu zielonego przycisku GuiProjekt program rozpocznie kompilację. 

Działanie programu

Po skompilowaniu projektu naszym oczom ukazuje się główne okno programu:

![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/d0a09ab0-b3ef-4eab-9f57-57c118a9b1d2)
Widzimy interaktywne logo kina, oraz cztery zdjęcia dostępnych filmów. Po kliknięciu na dowolny z nich wyświetlą się szczegółowe informacje o danej adaptacji. Przykładowo:

![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/112382f8-2d77-437c-b4d7-80b451842f6b)
Po kliknięciu ponownie w zdjęcie powrócimy do głównego menu, jednak po naciśnięciu przycisku w prawym dolnym rogu przechodzimy do kolejnego okna.
 
 ![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/437050c5-a70e-4cb9-8b50-a7a3c4c0d351)
Aby przejść dalej koniecznie trzeba wybrać jedną pozycję z każdej z trzech list. Po wybraniu filmu i dnia wyświetlają się pozycje dotyczące dostępnych godzin. W przypadku próby przejścia dalej bez zaznaczenia, którejkolwiek z pozycji zostanie wyświetlone ostrzeżenie o konieczności zaznaczenia wszystkich pozycji. 

![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/42afbe57-8efe-4026-893b-38d4d05077b1)
 Po naciśnięciu przycisku Strona główna wrócimy do menu głównego. Zaznaczmy wszystkie pozycje i przejdźmy dalej:
 
 ![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/264ddd9d-e8cf-4e19-b75f-34bffe3c0698)
W kolejnym menu wybieramy miejsca, zaznaczone miejsca wyświetlane są na zielono, z kolei zajęte na kolor czerwony (informacja pobierana z bazy danych). W przypadku próby przejścia dalej bez zaznaczenia żadnego miejsca pojawi się ostrzeżenie o konieczności dokonania wyboru. Zaznaczmy miejsca i przejdźmy dalej:

 ![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/511e1249-ff29-4ed4-bddf-d4970ed74f2a)
Kolejne okno to miejsce na uzupełnienie danych osoby kupującej. W przypadku podania błędnego formatu w dowolnym oknie tekstowym zostanie wyświetlony komunikat o błędnych danych. Przykładowo po wprowadzeniu cyfr w polu Nazwisko:

 ![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/72f2b957-46cf-4bb4-8915-dda43ca253ab)
Program automatycznie po zaznaczeniu jednej opcji z listy dotyczącej biletów uzupełnia drugą w odpowiedni sposób. W przypadku naciśnięcia przycisku Skasuj wszystko następuje obsługa delegata, który usuwa wszystkie wprowadzone zmiany w tym oknie. Aby przejść do kolejnego okna należy uzupełnić wszystkie pola oraz wybrać formę płatności. Wszystko musi się odbyć w prawidłowym formacie.

 ![image](https://github.com/Wojtylson/Kino-C-Sharp/assets/146847950/68c53cac-d7c0-43bd-91d1-01ae602da78f)
Na sam koniec wyświetlane jest okno, w którym widoczne jest podsumowanie transakcji. Te same informacje są również wyświetlane w pliku PDF, którego utworzenie jest możliwe po naciśnięciu przycisku Zapisz PDF. Ponadto w prawym górnym rogu znajduje się kod QR, którego zeskanowanie również zaprowadzi użytkownika do podsumowania transakcji.
 
Podział pracy
	Pracując nad projektem wiele godzin spędziliśmy razem, próbując wspólnymi siłami rozwiązać napotkane problemy. Nie mniej jednak możemy wyróżnić elementy, za które były odpowiedzialne poszczególne osoby.
Autorzy:
Wojciech Kantor
Filip Regulski
Wiktor Kostera
Filip Regulski:
•	Stworzenie logo oraz pliku GIF, 
•	Zadbanie o ogólną warstwę kolorystyczną projektu,
•	Zapis wyników projektu do pliku PDF,
•	Zaimplementowanie możliwości skanowania kodu QR.
Wojciech Kantor:
•	Zaimplementowanie bazy danych SQL,
•	Obsługa przekazywania obiektów pomiędzy oknami,
•	Zaimplementowanie zabezpieczeń przed wprowadzeniem danych w niepoprawnym formacie,
•	Zaimplementowanie własnego kształtu kontrolek przycisków przy wyborze miejsc.
Wiktor Kostera:
•	Zaimplementowanie list rozwijanych oraz związana z nimi obsługa zabezpieczeń,
•	Zaimplementowanie diagramu, interfejsu, delegata oraz klas,
•	Wprowadzenie obsługi zdjęć oraz obiektów Film koniecznych do poprawnego wyświetlania informacji,
•	Zadbanie o ogólną estetykę projektu, rozmieszczenie kontrolek itd.
