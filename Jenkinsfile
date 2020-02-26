pipeline{
    agent any
   
   environment {
            PATH = "$PATH:/root/.nvm/versions/node/v12.16.1/bin"
    }

    stages{
        stage('Workspace Clean') {
            steps {
                step([$class: 'WsCleanup'])
            }
        }
        
    stage('Checkout') {
        steps {
            git credentialsId:'fbedd5086dfeab07dc2052717911a5ad3f1b5862', url:'https://github.com/HansikaW/rambase-poc/', branch:'client'\
        }    
    }
    
    stage('Restore packages') {
        steps {
            dir('client') {
               sh "npm install" 
            }
        }
     }
     
     stage('Build'){
        steps{
            dir('client') {
               sh "npm run-script build"
               sh "npm build --prod " 
            }
         }
      }
        
     stage('Unit test'){
        steps{
           dir('client') {
              sh "npm run test:ci"
           } 
        }
    }
    
     stage('Publish'){
        steps{ 
            script{
              dir('client') {
                sh "docker build -t rambaseclient ."
                sh "docker tag hattelandclient hansikaw/rambaseclient:1.0"
                sh "docker push hansikaw/rambaseclient:1.0"
              }
            }
        }
     }
    }
    
    post{
     always{
       emailext body: "${currentBuild.currentResult}: Job   ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
       to: 'hansikaw@99x.lk',
       subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
      }
    }
  }
