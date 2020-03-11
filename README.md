# CICD

***Continuous integration (CI) and continuous delivery (CD) deliver software to a production environment with speed, safety, and reliability.***

**Continuous integration** focuses on blending the work products of individual developers together into a repository. Often, this is done several times each day, and the primary purpose is to enable early detection of integration bugs, which should eventually result in tighter cohesion and more development collaboration. 
The aim of **continuous delivery** is to minimize the friction points that are inherent in the deployment or release processes. Continuous deployment is a higher degree of automation, in which a build/deployment occurs automatically whenever a major change is made to the code.


## Jenkins

Jenkins is used to continuously build and test software projects, enabling developers to set up a CI/CD environment. There are so many ways to implement CI/CD in Jenkins such as, Blue Ocean, Free Style project and Pipelines. 
pipelines enable you to define the whole application lifecycle. Pipeline functionality helps Jenkins to support continuous delivery (CD). The Pipeline plugin was built with requirements for a flexible, extensible, and script-based CD workflow capability in mind.

## Types of Jenkins Pipelines:

### Pipeline Job: 
Pipeline job allows users to use Declarative pipeline and Scripted pipeline to create a pipeline for ***repository with single branch***. Declarative pipeline is a relatively new feature that supports the pipeline as code concept. It makes the pipeline code easier to read and write.


### Multibranch Pipeline: 
The Multibranch Pipeline allows users to automatically create a pipeline for ***each branch on your repository*** with the help of Jenkinsfile (stored along with your source code inside a Source Code Management (SCM); eg. GitHub). The Multibranch Pipeline project type enables you to implement different Jenkinsfiles for different branches of the same project. In a Multibranch Pipeline project, Jenkins automatically discovers, manages and executes Pipelines for branches which contain a Jenkinsfile in source control.
