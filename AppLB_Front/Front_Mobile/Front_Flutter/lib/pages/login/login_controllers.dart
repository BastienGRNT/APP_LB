import 'dart:convert';
import 'package:http/http.dart' as http;

class LoginController {
  static const String apiUrl = 'http://192.168.1.15:5125/api/Controllers_Login';

  static Future<String> login(String username, String password) async {
    try {
      final response = await http.post(
        Uri.parse(apiUrl),
        headers: {
          'Content-Type': 'application/json',
        },
        body: json.encode({
          'user_id': username,
          'user_password': password,
        }),
      );

      if (response.statusCode == 200) {
        final data = json.decode(response.body);
        return data['message'] ?? 'Connexion réussie';
      } else {
        final errorData = json.decode(response.body);
        return errorData['error'] ?? 'Erreur inconnue';
      }
    } catch (e) {
      return 'Erreur réseau : $e';
    }
  }
}
