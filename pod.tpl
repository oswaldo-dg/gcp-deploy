apiVersion: v1
kind: Pod
metadata:
  name: gcp-api-pod
  namespace: gcp-deployment
  labels:
    app: gcp
spec:
#  volumes:
#  - name: cert-storage
#    persistentVolumeClaim:
#      claimName: certs-pvc
  containers:
# STUB
  - name: gcp-stub-microservice
    image: gcr.io/GOOGLE_CLOUD_PROJECT/stub:COMMIT_SHA
    ports:
    - containerPort: 5001
    - containerPort: 5000
 #   volumeMounts:
 #   - name: cert-storage
 #     mountPath: "/https/"
    env:
    - name: ASPNETCORE_URLS
      value: "http://*:5000;https://*:5001"
    - name: ASPNETCORE_HTTPS_PORT
      value: "5001"
    - name: ASPNETCORE_Kestrel__Certificates__Default__Password
      value: "crypticpassword"
    - name: ASPNETCORE_Kestrel__Certificates__Default__Path
      value: "./localhost.pfx"
# API
  - name: gcp-api-microservice
    image: gcr.io/GOOGLE_CLOUD_PROJECT/api:COMMIT_SHA
    ports:
    - containerPort: 7001
    - containerPort: 7000
#    volumeMounts:
#    - name: cert-storage
#      mountPath: "/https/"
    env:
    - name: ASPNETCORE_URLS
      value: "http://*:7000;https://*:7001"
    - name: ASPNETCORE_HTTPS_PORT
      value: "7001"
    - name: ASPNETCORE_Kestrel__Certificates__Default__Password
      value: "crypticpassword"
    - name: ASPNETCORE_Kestrel__Certificates__Default__Path
      value: "./localhost.pfx"
    - name: api__cors
      value: "http://k8s.eccordion.com,https://k8s.eccordion.com,http://localhost,https://localhost"
    - name: api__wf
      value: "https://localhost:5001/"
# UI
  - name: gcp-ui-microservice
    image: gcr.io/GOOGLE_CLOUD_PROJECT/ui:COMMIT_SHA
    ports:
    - containerPort: 80
