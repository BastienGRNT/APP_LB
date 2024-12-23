import 'package:flutter/material.dart';
import 'package:Front_Flutter/pages/login/login.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Mon application !!!',
      debugShowCheckedModeBanner: false,
      home: LoginPage(),
    );
  }
}
