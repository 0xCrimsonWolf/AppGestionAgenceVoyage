
# Laboratoire final : Application de gestion d'une agence de voyage

> Projet final dans le cadre du cours  _Développement orienté objets et multitâche : Programmation orientée objet Windows- C#_

Debarsy William - 2021-2022

## Sujet de l'application

Faites pour les agents de voyages, l'application traitera de la gestion d'une agence de voyage. Elle permettra de gérer les destinations, les vols, les moyens de transports, les dates, les voyageurs, les logements, etc

## Organisation du code

Pour les classes, voici les parties principales, respectant le MVVM, on y retrouve forcément la View (généralement tout les .xaml), le Model (représentant les classes utiles à proprement parlé) et le ViewModel (l'intermédiaire entre les deux) :

Du côté WPF :

- Le **MainWindowViewModel.cs** : correspond au ViewModel dans l'architecture MVVM. Elle contiendra tout le code, les méthodes utiles, les fonctionnalités, ... 
-	Le **MainWindow.xaml (et .cs)** : est la fenêtre de démarrage de l'application, elle contient la fenêtre de login ainsi que le code qui va avec. Dans le constructeur de celle-ci, on y retrouve des accès aux registres de Windows. Les méthodes utilisées sont inscrites dans l'interface "**ILoginUtility**", interface implémenté par le ViewModel. On y voit 3 méthodes : **LoginCheck** (permettant de récupérer le login + password entré), **LoginCheckRegistry** (permettant de vérifier si le password entré est le bon) et le **GetHashSHA256** (permettant la simplification du cryptage en SHA256 des password)
- L' **ApplicationWindow.xaml (et .cs)** : est la fenêtre de base de l'application, c'est la fenêtre dite "GUI". Possédant une page d'accueil, une barre de navigation, des options, c'est de cette fenêtre que l'on pourra tout faire. 
- L' **OptionWindow.xaml (et .cs)** : cette fenêtre modale permettra d'y choisir le répertoire d'enregistrement ainsi que le thème de l'application (sombre ou clair). C'est par le billet d'un Event que celle-ci communiquera avec la fenêtre GUI. Afin de gérer une reconnaissance parfaite, ces deux options seront enregistrées dans la registry.
- L' **EnregistrementWindow.xaml (et .cs)** : c'est via cette fenêtre que se passeront les enregistrements. Deux types d'enregistrement (import/export) sont possible : en XML ou bien en binaire.
- Le **ModifierVoyageWindow.xaml** et **AjouterVoyageWindow.xaml (et .cs)** : sont les fenêtres en lien avec l'onglet "Voyages" dans l'application. Toutes deux modales, elles vont permettre d'ajouter et de modifier un voyage dans la liste.

Du côté Model : 
-   La classe  **Voyageur**  : elle contient les informations sur les voyageurs comme son nom l'indique (nom, prénom, sexe, age, ...)
-   La classe  **Destination**  : elle contient les informations sur les différentes destinations (continent, pays, ville, ...)
-   La classe  **MoyenDeTransport**  : sous forme d'héritage, elle donnera lieu à 3 autres classes : *TransportAerien*, *TransportMarin* et *TransportTerrestre*. Elle contient les différents moyens de transports pour les voyages (nom, type, poids, chargeUtile, nbPassager, ...)
- La classe **Logement** : elle contient tout ce qui est en rapport avec le logement c'est-à-dire, le type, le nom, l'adresse, etc.
- La classe **Voyage** : elle est la classe qui va rassembler toutes celles du dessus (références),  elle sera gérée par l'onglet "Voyages" dans l'application de base.


Les mots de passes stocké en registry et crypto sha256 + les autres données style les images
