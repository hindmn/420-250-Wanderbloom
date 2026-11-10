# Registre des risques - Wanderbloom

Échelles : P et I de 1 à 3. Criticité = P × I
(1-2 faible, 3-4 moyenne, 6-9 élevée). Revu à chaque sprint planning.

# Synthèse

| ID | Risque | Criticité | Responsable |
|--------|------|-----------------------------------|
| R1 | BF-06 et BF-10 pas terminés à temps | 9 (élevée) | Arielle |
| R2 | Conflits dans le comportement du joueur | 6 (élevée) | Hind |
| R3 | BF du niveau 2 qui ne décrivent plus la forêt | 6 (élevée) | Gaelle |
| R4 | Retard du niveau 3 sans échéance | 4 (moyenne) | Hind |
| R5 | Animator 2D jamais utilisé pour BF-07 | 4 (moyenne) | Arielle |
| R6 | Scripts portant le même nom au merge final | 4 (moyenne) | Arielle |
| R7 | Vol des chauves-souris désynchronisé de leur poursuite | 4 (moyenne) | Sara |
| R8 | Diamants non comptés qui bloquent la sortie de la mine | 3 (moyenne) | Sara |
| R9 | Fichiers .meta des dossiers générés par chaque membre | 3 (moyenne) | Gaelle |
| R10 | Effets de collecte des diamants mal déclenchés | 2 (faible) | Sara |

## R1 — BF-06 et BF-10 pas terminés à temps
 
- **Risque :** Parce que l'équipe a déjà pris du retard et que le TP UML
  (24 novembre) et le projet Unity (29 novembre) tombent la même semaine,
  il est possible que BF-06 (bond d'esquive) et BF-10 (perte d'un fruit)
  ne soient pas terminés à temps, ce qui compromettrait la remise du projet.
- **BF touchés :** BF-06, BF-10
- **Catégorie :** Planification
- **P :** 3 · **I :** 3 · **Criticité :** 9 (élevée)
- **Stratégie :** Réduire
- **Mitigation :** Les issues BF-06 et BF-10 ont une date d'échéance au
  20 novembre dans le Board, et leur avancement est annoncé à chaque daily.
- **Déclencheur :** Le 20 novembre, BF-06 ou BF-10 n'est pas fusionné dans main.
- **Contingence :** Un deuxième membre rejoint Arielle sur le BF en retard,
  et la version la plus simple du BF est livrée en premier.
- **Responsable :** Arielle
- **Statut :** Ouvert



## R2 — Conflits dans le comportement du joueur
 
- **Risque :** Parce que BF-01, BF-06 et BF-16 modifient tous le
  comportement du joueur, il est possible que des fusions entrent en
  conflit ou brisent un déplacement, ce qui entraînerait des jours de
  travail perdus sur plusieurs niveaux.
- **BF touchés :** BF-01, BF-06, BF-16
- **Catégorie :** Technique
- **P :** 2 · **I :** 3 · **Criticité :** 6 (élevée)
- **Stratégie :** Réduire
- **Mitigation :** Chaque BF ajoute son propre script au prefab du joueur
  au lieu de modifier le même script, et la répartition des scripts est
  écrite dans l'issue R2.
- **Déclencheur :** Un conflit apparaît sur le script ou le prefab du
  joueur, ou un déplacement ne fonctionne plus après une fusion dans main.
- **Contingence :** Revenir au dernier commit de main où le joueur se
  déplace correctement, puis refusionner les branches une à la fois en
  testant en PlayMode après chacune.
- **Responsable :** Hind
- **Statut :** Ouvert



## R3 — BF du niveau 2 qui ne décrivent plus la forêt
 
- **Risque :** Parce que la zone de Gaelle est passée d'un potager à une
  forêt après la remise du cahier des charges, il est possible que
  BF-16 à BF-21 et leurs issues, qui parlent encore de « plante mûre »,
  ne correspondent plus à ce qui est programmé, ce qui entraînerait une
  perte de points lors de l'évaluation des BF ou une réécriture du cahier
  des charges en fin de projet.
- **BF touchés :** BF-16, BF-17, BF-18, BF-19, BF-20, BF-21
- **Catégorie :** Exigences
- **P :** 3 · **I :** 2 · **Criticité :** 6 (élevée)
- **Stratégie :** Réduire
- **Mitigation :** Les issues BF-16 à BF-21 et la description du jalon
  « Level 2 : Forest » sont réécrites pour la forêt, et Gaelle coche
  chaque BF mis à jour dans l'issue R3.
- **Déclencheur :** Au moment de fermer une issue de BF-16 à BF-21, sa
  description ne correspond pas à ce que fait le jeu.
- **Contingence :** Avant la remise, Gaelle réécrit la description de
  chaque BF concerné pour qu'elle décrive le jeu livré, et la section du
  cahier des charges est mise à jour en une seule pull request.
- **Responsable :** Gaelle
- **Statut :** Ouvert



## R4 — Retard du niveau 3 sans échéance
 
- **Risque :** Parce que le jalon du niveau 3 (BF-01 à BF-05) est le seul
  sans date d'échéance, il est possible que le niveau 3 prenne du retard,
  ce qui entraînerait un blocage du parcours jusqu'au niveau 4.
- **BF touchés :** BF-01, BF-02, BF-03, BF-04, BF-05
- **Catégorie :** Planification
- **P :** 2 · **I :** 2 · **Criticité :** 4 (moyenne)
- **Stratégie :** Réduire
- **Mitigation :** Le jalon « Level 3 : Snowy Forest » a une date
  d'échéance dans GitHub, et chacun des BF-01 à BF-05 a une date dans le Board.
- **Déclencheur :** —
- **Contingence :** —
- **Responsable :** Hind
- **Statut :** Ouvert



## R5 — Animator 2D jamais utilisé pour BF-07
 
- **Risque :** Parce que BF-07 (animation de marche de la poule) utilise
  l'Animator 2D, une technique qu'Arielle n'a jamais essayée, il est
  possible que l'animation prenne deux fois plus de temps que prévu, ce
  qui retarderait les tests de configuration et en PlayMode qui en dépendent.
- **BF touchés :** BF-07
- **Catégorie :** Humain
- **P :** 2 · **I :** 2 · **Criticité :** 4 (moyenne)
- **Stratégie :** Réduire
- **Mitigation :** Arielle pousse sur sa branche, au plus tard le
  15 novembre, une scène de test où la poule joue son animation de marche
  avec l'Animator 2D.
- **Déclencheur :** —
- **Contingence :** —
- **Responsable :** Arielle
- **Statut :** Ouvert



## R6 — Scripts portant le même nom au merge final
 
- **Risque :** Parce que chaque membre crée ses propres scripts dans sa
  branche, il est possible que deux scripts portent le même nom (par
  exemple le compteur de fruits utilisé par BF-10) au merge final, ce qui
  empêcherait le projet de compiler.
- **BF touchés :** BF-10
- **Catégorie :** Technique
- **P :** 2 · **I :** 2 · **Criticité :** 4 (moyenne)
- **Stratégie :** Réduire
- **Mitigation :** La liste des noms de scripts, avec leur auteur, est
  écrite dans l'issue R6, et chaque membre y ajoute un nom avant de créer
  le script.
- **Déclencheur :** —
- **Contingence :** —
- **Responsable :** Arielle
- **Statut :** Ouvert



## R7 — Vol des chauves-souris désynchronisé de leur poursuite
 
- **Risque :** Parce que BF-15 (poursuite des chauves-souris) doit
  fonctionner avec BF-11 (animation de vol), il est possible que
  l'animation ne se synchronise pas correctement avec les déplacements
  des chauves-souris, ce qui entraînerait des mouvements incohérents et
  du temps supplémentaire pour corriger et tester ces deux fonctionnalités.
- **BF touchés :** BF-11, BF-15
- **Catégorie :** Technique
- **P :** 2 · **I :** 2 · **Criticité :** 4 (moyenne)
- **Stratégie :** Réduire
- **Mitigation :** Sara pousse sur sa branche, au plus tard le
  18 novembre, une scène de test où une chauve-souris poursuit le joueur
  avec son animation de vol.
- **Déclencheur :** —
- **Contingence :** —
- **Responsable :** Sara
- **Statut :** Ouvert



## R8 — Diamants non comptés qui bloquent la sortie de la mine
 
- **Risque :** Parce que BF-13 (compteur de diamants) doit enregistrer
  chaque diamant récupéré pour permettre au joueur d'atteindre les huit
  diamants nécessaires à la victoire, il est possible qu'une erreur dans
  la détection ou la mise à jour du compteur empêche certains diamants
  d'être comptabilisés, ce qui bloquerait la progression du joueur vers
  la sortie de la mine.
- **BF touchés :** BF-13
- **Catégorie :** Technique
- **P :** 1 · **I :** 3 · **Criticité :** 3 (moyenne)
- **Stratégie :** Réduire
- **Mitigation :** Avant de fusionner BF-13 dans main, Sara fait un test
  en PlayMode où le joueur ramasse les huit diamants et atteint la sortie,
  et elle coche ce test dans l'issue R8.
- **Déclencheur :** —
- **Contingence :** —
- **Responsable :** Sara
- **Statut :** Ouvert



## R9 — Fichiers .meta des dossiers générés par chaque membre
 
- **Risque :** Parce que la structure de dossiers a été poussée sur main
  sans les fichiers .meta des dossiers principaux (Art, Animations, Audio,
  Prefabs, Scripts, Tilemaps, UI), et sans que l'équipe soit avertie, il
  est possible que chaque membre commite sa propre version générée par
  Unity, ce qui entraînerait des conflits de fusion sur ces fichiers .meta
  dans main.
- **BF touchés :** Tout le projet
- **Catégorie :** Communication
- **P :** 3 · **I :** 1 · **Criticité :** 3 (moyenne)
- **Stratégie :** Réduire
- **Mitigation :** Les fichiers .meta des 7 dossiers sont commités sur main
  par une seule personne, et chaque membre confirme dans l'issue R9 avoir
  fait git pull avant de commiter dans ces dossiers.
- **Déclencheur :** —
- **Contingence :** —
- **Responsable :** Gaelle
- **Statut :** Ouvert



## R10 — Effets de collecte des diamants mal déclenchés
 
- **Risque :** Parce que BF-12 (particules lumineuses) et BF-14 (son du
  diamant) doivent se déclencher au moment de la collecte, il est possible
  que les effets se déclenchent plusieurs fois ou ne se déclenchent pas,
  ce qui entraînerait des incohérences visuelles et sonores lors de la
  récupération des diamants.
- **BF touchés :** BF-12, BF-14
- **Catégorie :** Technique
- **P :** 2 · **I :** 1 · **Criticité :** 2 (faible)
- **Stratégie :** Accepter
- **Mitigation :** —
- **Déclencheur :** —
- **Contingence :** —
- **Responsable :** Sara
- **Statut :** Ouvert