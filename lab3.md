# <p align="center"> Лабораторная работа №3. </p>

## <p align="center"> Прецедент «Начать игру» </p>

<p align="center"><img src="https://github.com/awlkmy/RTiPPO/assets/146245304/1be98cd3-c7cc-47d8-b130-468c1d59e27b"></img></p>

| Действие    | Игрок нажимает кнопку "Начать игру" |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Игра не запущена |
| Постусловия | Игра запущена |

| Действие    | Система инициирует создание новой игры и генерирует колоду карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Игра запущена |
| Постусловия | Сгенерирована колода карт |

| Действие    | Система раздает по 6 карт каждому игроку из сгенерированной колоды |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Сгенерирована колода карт |
| Постусловия | Игроки получили по 6 карт |

| Действие    | Система извлекает верхнюю карту из колоды и определяет ее масть как козырную |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Колода сгенирирована |
| Постусловия | Для игры определена козырная масть |

| Действие    | Система отображает козырь на игровом поле для всех игроков |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Для игры определена козырная масть |
| Постусловия | Козырная масть отображается для игроков |

| Действие    | Система определяет игрока с наименьшей козырной картой и передает ему ход |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Козырная масть отображается для игроков |
| Постусловия | Определен ведущий игрок, которому передан ход |

| Действие    | Игрок нажимает кнопку "Отменить игру" до момента, когда система объявит начало первого хода |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Игра запущена |
| Постусловия | Игра сбрасывает сгенерированную колоду карт, карты игроков и козырь |

| Действие    | Система возвращается в состояние ожидания начала игры |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Игра сбросила сгенерированную колоду карт, карты игроков и козырь |
| Постусловия | Игра в состоянии ожидания начала игры |

| Действие    | У игроков отсутствуют козырные карты |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | Игроки получили по 6 карт |
| Постусловия | Случайным образом определен ведущий игрок |

| Действие    | Система случайным образом выбирает ведущего игрока |
| :---        | :--- |
| Ссылки      | Прецеденты: «Начать игру» |
| Предусловия | У игроков отсутствуют козырные карты |
| Постусловия | Ведущий игрок определен |

## <p align="center"> Прецедент «Подкинуть карты» </p>

<p align="center"><img src="https://github.com/awlkmy/RTiPPO/assets/146245304/e3bf17fe-8d7c-43ce-a27d-8d70b452938b"></img></p>

| Действие    | Ведущий игрок выбирает и подкидывает от 1 до 4 карт на стол |
| :---        | :--- |
| Ссылки      | Прецеденты: «Подкинуть карты» |
| Предусловия | Объявлено начало хода и определен ведущий игрок |
| Постусловия | Ведущий игрок подкинул карты отбивающемуся |

| Действие    | Система отображает подкинутые карты на столе |
| :---        | :--- |
| Ссылки      | Прецеденты: «Подкинуть карты» |
| Предусловия | Ведущий игрок подкинул карты отбивающемуся |
| Постусловия | Подкинутые карты отображены на столе |

| Действие    | Ведущий игрок заканчивает ход |
| :---        | :--- |
| Ссылки      | Прецеденты: «Подкинуть карты» |
| Предусловия | Подкинутые карты отображены на столе |
| Постусловия | Ведущий игрок завершил ход |

| Действие    | Система передает ход отбивающемуся игроку |
| :---        | :--- |
| Ссылки      | Прецеденты: «Подкинуть карты» |
| Предусловия | Ведущий игрок завершил ход |
| Постусловия | Ход передан отбивающемуся игроку |

| Действие    | Ведущий игрок подкидывает карты исходя из тех, какие есть на столе |
| :---        | :--- |
| Ссылки      | Прецеденты: «Подкинуть карты» |
| Предусловия | На столе есть ранее подкинутые карты |
| Постусловия | Ведущий игрок подкинул карты |

## <p align="center"> Прецедент «Отбить карты» </p>

<p align="center"><img src="https://github.com/awlkmy/RTiPPO/assets/146245304/bdb1ee42-af3e-41fa-a453-cc6ea9422f37"></img></p>

| Действие    | Отбивающийся игрок выбирает карты и отбивает подкинутые карты ведущим игроком |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Ведущий игрок подкинул карты отбивающемуся |
| Постусловия | Отбивающийся игрок отбил подкинутые карты |

| Действие    | Система отображает подкинутые карты поверх отбиваемых |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Отбивающийся игрок отбил подкинутые карты |
| Постусловия | Карты отображены на столе поверх подкинутых |

| Действие    | Отбивающийся игрок заканчивает ход |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Отбивающийся игрок отбил подкинутые карты |
| Постусловия | Отбивающийся игрок завершил ход |

| Действие    | Система передает ход ведущему игроку для подкидывания дополнительных карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Отбивающийся игрок завершил ход |
| Постусловия | Ход передан ведущему игроку |

| Действие    | Игрок нажимает кнопку "Взять карты" |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Ход передан отбивающемуся игроку |
| Постусловия | Отбивающийся игрок взял карты |

| Действие    | Переход к прецеденту "Взять карты" |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты», «Взять карты» |
| Предусловия | Отбивающийся игрок нажал кнопку "Взять карты" |
| Постусловия | Отбивающийся игрок взял карты |

| Действие    | Отбивающийся игрок подкидывает все свои карты |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Ход передан отбивающемуся игроку |
| Постусловия | Отбивающийся игрок отбил подкинутые карты |

| Действие    | Система "складывает" карты в отбой |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Игроки завершили свои ходы |
| Постусловия | Отбитые карты находятся в отбое |

| Действие    | Система объявляет о завершении хода |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Карты находятся в отбое |
| Постусловия | Текущий ход завершен |

| Действие    | Ведущий игрок отказывается подкидывать дополнительные карты |
| :---        | :--- |
| Ссылки      | Прецеденты: «Отбить карты» |
| Предусловия | Ход передан ведущему игроку |
| Постусловия | Ход передан отбивающемуся игроку |

## <p align="center"> Прецедент «Взять карты» </p>

<p align="center"><img src="https://github.com/awlkmy/RTiPPO/assets/146245304/b0699972-89d8-47e8-aca2-b554d429c1ad"></img></p>

| Действие    | Отбивающийся игрок нажимает кнопку "Взять карты" |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Ход передан отбивающемуся игроку |
| Постусловия | Игрок нажал кнопку "Взять карты" |

| Действие    | Система передает ход ведущему игроку для подкидывания дополнительных карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Отбивающийся игрок завершил свой ход |
| Постусловия | Ход передан ведущему игроку |

| Действие    | Ведущий игрок подкидывает дополнительные карты |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Ход передан ведущему игроку |
| Постусловия | Ведущий игрок подкинул дополнительные карты |

| Действие    | Система отображает подкинутые карты на столе |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Ведущий игрок подкинул дополнительные карты |
| Постусловия | Подкинутые карты отображены на столе |

| Действие    | Ведущий игрок завершает ход |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Ведущий игрок подкинул карты |
| Постусловия | Ведущий игрок завершил свой ход |

| Действие    | Система убирает карты со стола и переносит их к картам отбивающегося игрока |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Ведущий игрок подкинул карты и завершил свой ход |
| Постусловия | Отбивающийся игрок получил карты со стола |

| Действие    | Система выводит уведомление о завершении текущего хода |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Игроки завершили свои ходы |
| Постусловия | Текущий ход завершен |

| Действие    | Ведущий игрок отказывается подкидывать дополнительные карты |
| :---        | :--- |
| Ссылки      | Прецеденты: «Взять карты» |
| Предусловия | Ход передан ведущему игроку |
| Постусловия | Ведущий игрок завершил свой ход |

## <p align="center"> Прецедент «Добор карт» </p>

<p align="center"><img src="https://github.com/awlkmy/RTiPPO/assets/146245304/2619f796-3797-427d-b511-b5ecc1563f5a"></img></p>

| Действие    | Система предоставляет возможность ведущему игроку добрать необходимое количество карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | Завершен текущий ход |
| Постусловия | Ведущий игрок имеет возможность добрать карты |

| Действие    | Ведущий игрок добирает от 1 до 6 карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | Ведущий игрок имеет возможность добрать карты |
| Постусловия | Ведущий игрок добрал карты |

| Действие    | Система предоставляет возможность отбивающемуся игроку добрать необходимое количество карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | Ведущий игрок добрал карты |
| Постусловия | Отбивающийся игрок имеет возможность добрать карты |

| Действие    | Отбивающийся игрок добирает от 1 до 6 карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | Отбивающийся игрок имеет возможность добрать карты |
| Постусловия | Отбивающийся игрок добрал карты |

| Действие    | Система переопределяет роли: ведущий игрок становится отбивающимся, а отбивающийся - ведущим |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | Отбивающийся игрок добрал карты |
| Постусловия | В игре переопределены роли ведущего и отбивающегося игроков |

| Действие    | Система уведомляет игроков о начале нового хода |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | В игре переопределены роли ведущего и отбивающегося игроков |
| Постусловия | Объявлено начало нового хода |

| Действие    | Система предоставляет возможность ведущему игроку подкинуть карты |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | Объявлено начало нового хода |
| Постусловия | Ход передан ведущему игроку |

| Действие    | Игроки имеют на руках 6 и более карт |
| :---        | :--- |
| Ссылки      | Прецеденты: «Добор карт» |
| Предусловия | Игроки завершили ходы |
| Постусловия | Переопределены роли ведущего и отбивающегося игроков |

## <p align="center"> Прецедент «Завершение игры» </p>

<p align="center"><img src="https://github.com/awlkmy/RTiPPO/assets/146245304/3e8f5c79-53fe-4725-8769-3346b81d84f7"></img></p>

| Действие    | Ведущий игрок подкидывает все свои карты |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Ход передан ведущему игроку |
| Постусловия | Ведущий игрок подкинул карты |

| Действие    | Система отображает подкинутые карты на столе |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Ведущий игрок подкинул карты |
| Постусловия | Карты отображены на столе |

| Действие    | Ведущий игрок завершает ход |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Карты отображены на столе |
| Постусловия | Ведущий игрок завершил ход |

| Действие    | Система передает ход отбивающемуся игроку |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Ведущий игрок завершил ход |
| Постусловия | Ход передан отбивающемуся игроку |

| Действие    | Отбивающийся игрок выбирает карты и отбивает подкинутые карты ведущим игроком |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Ход передан отбивающемуся игроку |
| Постусловия | Отбивающийся игрок отбивает подкинутые карты |

| Действие    | Система отображает подкинутые карты поверх отбиваемых |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Отбивающийся игрок отбил подкинутые карты |
| Постусловия | Карты отображены поверх отбиваемых |

| Действие    | Отбивающийся игрок завершает ход |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Карты отображены поверх отбиваемых |
| Постусловия | Отбивающийся игрок завершил ход |

| Действие    | Система "складывает" карты в отбой |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Отбивающийся игрок завершил свой ход |
| Постусловия | Игра сложила карты в отбой |

| Действие    | Система определяет ведущего игрока победителем |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | У ведущего игрока отсутствуют карты |
| Постусловия | Ведущий игрок определен победителем |

| Действие    | Система предоставляет возможность начать новую игру или войти в режим ожидания начала игры |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Определен победитель |
| Постусловия | Передана возможность начать новую игру или выйти в режим ожидания начала новой игры |

| Действие    | Отбивающийся игрок нажимает кнопку "Взять карты" |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Ход передан отбивающемуся игроку |
| Постусловия | Отбивающийся игрок нажал кнопку "Взять карты" |

| Действие    | Система убирает карты со стола и передает их к картах отбивающегося игрока |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Отбивающийся игрок нажал кнопку "Взять карты" |
| Постусловия | Карты со стола переданы отбивающемуся игроку |

| Действие    | Отбивающийся отбился всеми своими картами |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | Ход передан отбивающемуся игроку |
| Постусловия | Отбивающийся игрок отбился всеми подкинутыми картами |

| Действие    | Система объявляет ничью |
| :---        | :--- |
| Ссылки      | Прецеденты: «Завершение игры» |
| Предусловия | У игроков не осталось на руках карт |
| Постусловия | Объявлена ничья |
