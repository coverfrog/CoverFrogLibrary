# CoverFrogLibrary

> Code Develop Custom Rule


> 모든 값은 항상 배열로 받아 올 것이라는 전제로 받아올 것

다수의 값에서 하나의 값만 가져가는 형태에서
하나의 값만 인용하는 경우 큰 문제가 없지만

하나의 값에서 다수의 값을 가져가는 형태일시
함수가 갈리던가 흐름 자체가 갈리는 가능성이 존재한다.

> 함수 설계시 호출자를 특정가능하거나 상위 요소로 압축이 가능한 경우 Sender 정보를 포함 시킬 것

Exampe)
  1 ) public void Recv(Pow pow, string msg)
  2 ) public void Recv<T>(T pow, string msg) where T : Pow
  3 ) public void Recv(Component sender, string msg)

호출자를 함수에 포함 하는 이유는 
누가 호출 했는지에 대한 관계 확인을 위함이다.
