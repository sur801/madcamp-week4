# Mad Camp 4th week

**카이스트 몰입 캠프 4주차 프로젝트**  

**프로젝트 명** : AR Bubble Fighter

**프로젝트 기간 :** 2020.07.30 ~ 2020.08.05

**개발 환경 :** Unity, C#, 3d Max

**본인 역할 :** 

- 다오 캐릭터 모델링
- 물풍선 던지기, 캐릭터와 충돌 애니메이션 구현
- 물풍선에 맞을 시 HP 줄어 들도록 구현.



## AR Bubble Fighter

- 추억의 게임 크레이지 아케이드를, Unity를 이용해Ar(Augmented Reality, 증강현실) Mobile 게임으로 구현해 보았다.

### 기본 게임 룰

- 배찌와 다오와 서로 물풍선을 던지며 싸우는 게임
- 내가 먼저 배찌와 다오를 다 해치우면 이김
- 배찌와 다오를 먼저 다 해치우기 전에 내 HP가 다 떨어지면 짐.
- 배찌와 다오를 해치우면, 그 자리에 HP포션이나, 물풍선 아이템이 생김

### Enemy(배찌와 다오)의 설정 값

- 1 frame 마다 카메라(Player) 위치를 찾아서, 그 방향으로 몸을 튼다.
- default로 고개를 좌우로 흔드는 애니메이션 실행함.
- 그리고 공을 던지는 모션을 함.
- 물풍선을 맞으면 쓰러지고, 아이탬을 뱉어냄. 그리고 사라짐.
- 만약 Player가 지면, 신나서 춤을 추는 애니메이션을 실행 함.
- 배찌와 다오는 각각 Fuzer와 3d Max를 이용해 모델을 직접 만듦.

### 게임 실행 화면

1. 시작. 먼저 평면을 인식 하기 위해 휴대폰을 상하좌우로 움직여야 함.  
   <img src="https://user-images.githubusercontent.com/5088280/91379602-07950d00-e85e-11ea-8bd3-7937b1f220db.jpeg" width="150" height="270">  

2. 평면 인식 후, 화면을 탭 하면 random한 위치에 배찌 두명, 다오 두명이 생김.
   <img src="https://user-images.githubusercontent.com/5088280/91379610-0a8ffd80-e85e-11ea-888d-1efa2609e43e.jpeg" width="150" height="270">
   그리고 그 후에, 내 화면을 한번 더 탭하면 앞에 내 물풍선이 생김.  

3. 배찌와 다오가 던지는 물풍선을 맞으면 HP가 줄어듦.
   <img src="https://user-images.githubusercontent.com/5088280/91379618-0c59c100-e85e-11ea-8ade-76f0142ff8f1.jpeg" width="150" height="270">  

4. 다오를 내 물풍선으로 맞추면 넘어지면서 죽고, 그 자리에 포션 아이템이 생김.
   <img src="https://user-images.githubusercontent.com/5088280/91379627-1085de80-e85e-11ea-8906-4f2291c8579b.jpeg" width="150" height="270">  

5. 포션을 먹기 위해서는 포션을 내 물풍선으로 다시 맞춰야 함. 포션을 먹으면 HP가 늘어남.
   <img src="https://user-images.githubusercontent.com/5088280/91379630-124fa200-e85e-11ea-805e-5623ca8eed3f.jpeg" width="150" height="270">  

6. 배찌를 맞추면 내 물풍선 크기를 키워주는 아이템이 생김.
   <img src="https://user-images.githubusercontent.com/5088280/91379632-14196580-e85e-11ea-9815-3b9be2be319e.jpeg" width="150" height="270">  

7. 물풍선 아이템을 먹고나니 물풍선 크기가 커짐.
   <img src="https://user-images.githubusercontent.com/5088280/91379633-154a9280-e85e-11ea-9b98-17e9bd76239e.jpeg" width="150" height="270">  

8. 이긴 화면, 진 화면

<img src="https://user-images.githubusercontent.com/5088280/91382893-bdb02500-e865-11ea-8fcb-a8f066418948.jpeg" width="150" height="270"> <img src="https://user-images.githubusercontent.com/5088280/91382884-b9840780-e865-11ea-9a17-ed2a6bb411b1.jpeg" width="150" height="270"> <img src="https://user-images.githubusercontent.com/5088280/91382890-bb4dcb00-e865-11ea-958d-5e32275cd0d3.jpeg" width="150" height="270">  
