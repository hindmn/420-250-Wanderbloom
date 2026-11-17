# 🌿 Wanderbloom

**Un jeu d'aventure RPG en 2D, développé avec Unity et C#.**

Wanderbloom est un jeu d'aventure en pixel art dans lequel le joueur explore un monde composé de quatre environnements uniques. À travers différentes missions, il doit collecter des ressources, surmonter des obstacles, éviter les ennemis et progresser jusqu'à la destination finale.

Le projet est développé en équipe dans le cadre du cours **420-250 — Collaboration**, au Cégep Ahuntsic.

## 🎮 Présentation du jeu

Wanderbloom propose une aventure en vue de dessus (*top-down*) combinant exploration, collecte et progression.

Le joueur traverse quatre niveaux, chacun possédant son propre environnement et ses défis.

### 🗺️ Les quatre niveaux

| Niveau | Environnement | Description |
|---|---|---|
| 01 | 🏡 Village | Découverte du monde et premières missions |
| 02 | 🌲 Forêt | Exploration, collecte de ressources et rencontres avec les ennemis |
| 03 | ❄️ Forêt enneigée | Progression dans un environnement hivernal |
| 04 | 💎 Mine abandonnée | Exploration des salles, collecte de diamants et affrontement des chauves-souris |

## ✨ Fonctionnalités

- **Exploration 2D :** déplacement du personnage dans différents environnements en pixel art.
- **Collecte de ressources :** récupération d'objets nécessaires à la progression.
- **Ennemis :** présence de créatures animées avec différents comportements.
- **Animations :** animations du personnage et des éléments interactifs.
- **Interface utilisateur :** affichage d'informations comme les points de vie et les objets collectés.
- **Effets visuels et sonores :** animations, effets de particules, musique et sons d'interaction.

*Certaines fonctionnalités décrites sont développées sur des branches de travail et peuvent ne pas encore être intégrées à la branche principale.*

## 🕹️ Contrôles

| Touche | Action |
|---|---|
| W | Se déplacer vers le haut |
| A | Se déplacer vers la gauche |
| S | Se déplacer vers le bas |
| D | Se déplacer vers la droite |

Les contrôles et interactions supplémentaires peuvent varier selon le niveau.

## 🛠️ Technologies utilisées

- **Unity 6** — Moteur de jeu
- **C#** — Programmation des mécaniques et interactions
- **Unity Tilemap** — Construction des environnements 2D
- **Unity Animator** — Gestion des animations
- **Unity Input System** — Gestion des contrôles du joueur
- **Git** — Gestion des versions
- **GitHub** — Collaboration et suivi des tâches

## 📁 Structure du projet

```text
420-250-Wanderbloom/
├── Assets/
│   ├── Animations/
│   ├── Art/
│   ├── Audio/
│   ├── Prefabs/
│   ├── Scenes/
│   ├── Scripts/
│   ├── Settings/
│   ├── Tilemaps/
│   └── UI/
├── Packages/
├── ProjectSettings/
└── README.md
```

Les ressources, scripts et scènes sont organisés par catégorie afin de faciliter le développement et la maintenance du projet.

## 🚀 Installation et lancement

### Prérequis

- Unity Hub
- Une version compatible d'Unity 6
- Git

### Installation

**1. Cloner le dépôt**

```bash
git clone https://github.com/hindmn/420-250-Wanderbloom.git
```

**2. Ouvrir le projet**

- Lancer Unity Hub.
- Cliquer sur **Add project from disk**.
- Sélectionner le dossier `420-250-Wanderbloom`.
- Ouvrir le projet avec la version Unity appropriée.

**3. Lancer le jeu**

- Dans Unity, ouvrir une scène située dans `Assets/Scenes/`.
- Cliquer sur **Play** pour démarrer la simulation.

> Pour consulter des fonctionnalités encore en développement, sélectionner la branche correspondante avant d'ouvrir le projet.

## 👥 Équipe de développement

| Membre | GitHub |
|---|---|
| Sara Belhadj | [@Sara-Belhadj](https://github.com/Sara-Belhadj) |
| Hind Manouzi | [@hindmn](https://github.com/hindmn) |
| Arielle Talabert | [@TArielle07](https://github.com/TArielle07) |
| Gaelle Espérance Baman Lissom | [@Gaeeelle](https://github.com/Gaeeelle) |

## 🤝 Organisation et collaboration

Le développement du jeu est organisé à l'aide de Git et GitHub.

- **Branches :** développement des fonctionnalités et des niveaux.
- **Issues :** suivi des tâches, des besoins fonctionnels et des améliorations.
- **Commits :** historique des modifications réalisées.
- **Pull Requests :** intégration et révision des contributions.

Les modifications sont développées et vérifiées avant leur intégration dans la branche principale.

## 🎨 Ressources graphiques

Le jeu utilise des ressources pixel art, notamment des éléments issus des packs **Sprout Lands** et **Sorry Pack**.

Les crédits et conditions de licence des ressources externes doivent être conservés et respectés.

---

*Wanderbloom — Un projet collaboratif de développement de jeu vidéo en 2D.* 🌿
