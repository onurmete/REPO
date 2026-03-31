# TestApi - .NET 8 REST API + Docker + Kubernetes + GitLab CI/CD

Bu proje, basit bir .NET 8 REST API uygulamasının Docker ile containerize edilmesi ve Kubernetes ortamında çalıştırılmasını göstermektedir.

## 🚀 Proje Yapısı

project-root/
│
├── TestApi/
│ ├── Program.cs
│ ├── Dockerfile
│ └── TestApi.csproj
│
├── k8s/
│ ├── deployment.yaml
│ └── service.yaml
│
├── .gitlab-ci.yml
└── README.md


---

## 🧱 Uygulama Hakkında

API aşağıdaki endpoint’i sağlar:



GET /health


### Örnek response:
```json
{
  "status": "ok",
  "version": "1.0.0"
}

🛠️ 1. Projeyi Build Etme
cd TestApi
dotnet restore
dotnet build

🐳 2. Docker Image Oluşturma ve Çalıştırma
Image build:
docker build -t testapi ./TestApi

Container çalıştırma:
docker run -d -p 8080:8080 testapi

Test:
curl http://localhost:8080/health

☸️ 3. Kubernetes Deploy
Minikube başlat:
minikube start

Deployment ve Service oluştur:
kubectl apply -f k8s/deployment.yaml
kubectl apply -f k8s/service.yaml

Pod kontrol:
kubectl get pods

Servise erişim:
minikube service myapi-service


veya:

kubectl port-forward service/myapi-service 8080:80

🔍 4. Health Check Testi
curl http://localhost:8080/health

⚙️ 5. GitLab CI/CD Pipeline

Pipeline aşağıdaki adımları içerir:

build → .NET uygulaması build edilir

docker build → image oluşturulur

image push → GitLab registry’ye gönderilir

deploy → Kubernetes’e deploy edilir

Pipeline .gitlab-ci.yml dosyasında tanımlıdır.

🧪 Kullanılan Teknolojiler

.NET 8

Docker (multi-stage build)

Kubernetes (Deployment + Service)

GitLab CI/CD

📌 Notlar

Uygulama container içinde 8080 portunda çalışır

Kubernetes readiness ve liveness probe /health endpoint’ini kullanır

Deployment 1 replica olarak yapılandırılmıştır

✅ Örnek Test Komutları
curl http://localhost:8080/health