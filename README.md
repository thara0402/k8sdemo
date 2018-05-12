# k8sdemo



## Swagger

https://www.nuget.org/packages/Swashbuckle.AspNetCore

```shell-session
$ dotnet add package Swashbuckle.AspNetCore --version 2.4.0

```

## Docker

```shell-session
$ docker build -t thara0402/k8sdemo:0.3.0 ./
$ docker run --rm -it -p 8000:80 --name k8sdemo thara0402/k8sdemo:0.3.0
$ docker push thara0402/k8sdemo:0.3.0

```

## K8s

```shell-session
$ kubectl run demoapp --image thara0402/k8sdemo:0.3.0
$ kubectl expose deployments demoapp --port=80 --type=LoadBalancer
$ kubectl scale deployment demoapp --replicas=3

```
