﻿using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace AlexM
 {
	 [RequireComponent(typeof(Movement_ForwardAM)), RequireComponent(typeof(Movement_TurningAM)),RequireComponent(typeof(ObstacleDetector))]
	 public class Controller : MonoBehaviour
	 {
		 public float dist;
		 private Movement_ForwardAM _FWD_MV;
		 private Movement_TurningAM _TRN_MV;
		 private ObstacleDetector _detector;
		 private void Awake()
		 {
			 _FWD_MV = GetComponent<Movement_ForwardAM>();
			 _TRN_MV = GetComponent<Movement_TurningAM>();
			 _detector = GetComponent<ObstacleDetector>();
		 }

		 private void Update()
		 {
			 _detector.Detect_FWD();
			 Move();
		 }

		 private void Move()
		 {
			 
			 _detector.detector_fwd_dist += f => { dist = f; };

			 if (dist >= 10)
			 {
				 _FWD_MV.zForce = 20;
			 }
			 else if (dist < 10)
			 {
				 _FWD_MV.zForce = 0;
			 }
		 } 
	 }

 }