(("PhysicsEngine" 
  DefManager (		 
			
 			("CarBody" ("CAR_BODY"
						  vecCenterOfGravity 0 -1.37 0.26))

				


			   ("Car" ("CAR_ROOT"
					  CarId 2
					  InverseMass     0.000869
					  vecLocalInverseInertiaDiagonal 0.0010 0.002 0.00092

					  EffWheelRadius  		0.315000
					  

					  MaxSteeringLock		2.35
					  SteeringRackRatio		+0.040
					  
					  FrontArea			2.0
					  DragCoefficient		0.5

					  SubTics	      1
						
					Engine	("Engine"
							Turbo 0
							
							VE00	0.50
							VE01	0.50
							VE02	0.65
							VE03	0.70
							VE04	0.80
							VE05	0.90
							VE06	0.93
							VE07	0.95
							VE08	0.97
							VE09	0.98
							VE10	0.99
							VE11	1.0
							VE12	1.0
							VE13	0.99
							VE14	0.98
							VE15	0.8
						)

					  Drive           ("Drive"
									DriveType 3
									EngineInertia		0.1
									GearBoxInertiaIn	0.1
									GearBoxInertiaOut	0.01
		
									MaxHandbrakePressure	20000000			
							
									NumberOfGears 	8						
									
									WheelInertia	2.0								
							
									   )
					ControlUnit	("ControlUnit"	
									   
									CenterDiffHandbrakeRelease 0.5
									LeftFootBrakeThreshold 0.2
			
									RPMLimit 8500

									   Gear0Upshift		0.0
									   Gear0Downshift	0.0
									   Gear1Upshift		0.0
									   Gear1Downshift	0.0
									   Gear2Upshift		8300.0
									   Gear2Downshift	0.0
									   Gear3Upshift		8300.0
									   Gear3Downshift  	5400.0
									   Gear4Upshift		8300.0
									   Gear4Downshift	5600.0
									   Gear5Upshift		8300.0
									   Gear5Downshift	5800.0
									   Gear6Upshift		8300.0
									   Gear6Downshift	5800.0
									   Gear7Upshift		0.0
									   Gear7Downshift	5800.0
						
					
									   )
						
					  iCollisionMesh	1
					  ))

			("HingedBody" ("CAR_DOOR_L"

							
							vecHingeAxis_RF 	 0.0  0.0  1.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 0.817 -2.110  0.524

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0 -0.5  0.0
							vecFaceNormal_BF	 0.0  0.0  -1.0

							HingeMinAngle		 -2.1
							HingeMaxAngle		 0.01
							HingeDefaultAngle	 0.01

							InverseMass		 0.05
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							InertiaHingeAxis	 5.0	

							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							FaceArea		1.0
							
							Spring0Type		2
							Spring0Pos		-0.75	
							Spring0Stiff		5000.0
							Spring0Damp		100.0
							Spring0MaxDisp		0.05
							Spring0Span		0.73
			
							BodyId			0

						 ))

				("HingedBody" ("CAR_DOOR_R"

							vecHingeAxis_RF 	 0.0  0.0  -1.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 -0.817 -2.110  0.524

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0 -0.5  0.0
							vecFaceNormal_BF	 0.0  0.0  -1.0

							HingeMinAngle		 -2.1
							HingeMaxAngle		 0.01
							HingeDefaultAngle	 0.01

							InverseMass		 0.05
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							
							InertiaHingeAxis	 5.0	

							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							FaceArea		1.0
							
							Spring0Type		2
							Spring0Pos		-0.75	
							Spring0Stiff		5000.0
							Spring0Damp		100.0
							Spring0MaxDisp		0.05
							Spring0Span		0.73

							BodyId			1							
		

						 ))

				("HingedBody" ("CAR_BONNET"

							vecHingeAxis_RF 	 1.0  0.0  0.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 0.700 -2.132  0.707
							vecFaceNormal_BF	 0.0  -0.45  -0.83939

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.700  0.6  0.05

							HingeMinAngle		 -1.5
							HingeMaxAngle		 -0.0
							HingeDefaultAngle	 -0.0

							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							InertiaHingeAxis	 1.5

							FaceArea		2.0

							Spring0Type		2
							Spring0Pos		-1.05	
							Spring0Stiff		2000.0
							Spring0Damp		20.0
							Spring0MaxDisp		0.07
							Spring0Span		1.00

							Sleepable		 1	
					  		SleepDelay		 2.0
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 1.0	

							BodyId			2
								

							

						 ))


				("HingedBody" ("CAR_EXHAUSTPIPE"

							vecHingeAxis_RF 	 1.0  0.0  0.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 -0.175  -0.094  0.073

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0  -0.3  0.0

							HingeMinAngle		 -0.8
							HingeMaxAngle		 +0.2
							HingeDefaultAngle	 +0.1

							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							InertiaHingeAxis	 1.5	

							Spring0Type		2
							Spring0Pos		0.05	
							Spring0Stiff		9000.0
							Spring0Damp		150.0
							Spring0MaxDisp		0.5
							Spring0Span		0.03

							Sleepable		 1	
					  		SleepDelay		 2.0
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 1.0	

								
							Unlocked		 1

							BreakChain		 1

							BodyId			3

						 ))


				("MountedBody" ("CAR_BUMPER_F"

							vecBasePoint_PRF	0.0 -2.990 0.265
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			0

	

						 ))


				("MountedBody" ("CAR_BUMPER_B"

							vecBasePoint_PRF	0.0 0.384 0.286
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			1

	

						 ))


				("MountedBody" ("CAR_WING"

							vecBasePoint_PRF	0.0 -0.087 1.145
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			2
	

						 ))
	 
)))
